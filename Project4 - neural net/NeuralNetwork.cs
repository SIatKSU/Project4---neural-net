using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project4___neural_net
{

    //main NeuralNet class
    class NeuralNetwork
    {
        public const int NUM_DIGITS = 10;           //0,1,2,3,4,5,6,7,8,9
        public const int NUM_BITS = 64;             //64 bits per digit.  8x8 bits
                                                    //input file has 65th bit, which is the actual value.
        public const int MAX_VAL = 16;              //bit values ranges from 0-16.

        public const double INIT_WEIGHT_MIN = 0.01; //initial weight of each connection will be random number between
        public const double INIT_WEIGHT_MAX = 0.02; //INIT_WEIGHT_MIN and INIT_WEIGHT_MAX. 
                                                    //small because we don't want the outputs were all getting pushed to 1.

        public static double ALPHA;                 //learning rate. 
                                                    //3857 training samples, so ~400 samples per digit to learn from.

        public static Random random = new Random();              //pseudo-random number generator


        public Form1 formObj;       //to access the values from the DataGridView on the form.

        public int[][] trainingsetRawInputs = null;
        public int[][] testingsetRawInputs = null;


        //Neural Network settings
        public int numLayers;
        public Layer[] layers;

        double[] inputs;            //input layer.  rawInputs scaled to values between 0 and 1.
                                    //inputs[0-63] = digits.
        int inputValue;             //what digit it actually is.

        double[] error;             //difference between actual and expected

        //example: Layer 0 has 30 nodes.  
        //Each node in Layer 0 has 64 connections coming into it, plus connection to bias node.
        public class Layer
        {
            public Node[] nodes;
            public int numBackConnections;  //number of connections from each node in this layer to the previous layer
            public int numNodes;


            
            public Layer(int numNodes, int numWeights)
            {
                this.numNodes = numNodes;
                numBackConnections = numWeights;
                nodes = new Node[numNodes];
                for (int i = 0; i < numNodes; i ++)
                {
                    nodes[i] = new Node(numWeights);
                }          
            }

            public class Node
            {
                //each node has weights coming into it from the previous layer.
                public double[] weights;

                //each node also has 1 connection to a bias node. (bias Node is always 1, so we just need the weight)
                public double biasWeight;

                public double fx;   //calculated value of f(x).  summation of weight_i * input_i, for each input_i.
                public double gx;   //calculated value of g(x) - running f(x) through sigmoid function.

                public double delta;       //calculated error term used in back-propagation

                public Node(int numWeights)
                {
                    weights = new double[numWeights];
                    for (int i = 0; i < numWeights; i++)
                    {
                        //initialize the weights to this node with pseudo-random numbers between INIT_WEIGHT_MIN and INIT_WEIGHT_MAX.
                        weights[i] = random.NextDouble() * (INIT_WEIGHT_MAX - INIT_WEIGHT_MIN) + INIT_WEIGHT_MIN;
                    }
                    biasWeight = random.NextDouble() * (INIT_WEIGHT_MAX - INIT_WEIGHT_MIN) + INIT_WEIGHT_MIN;
                    //Console.WriteLine("Weights Check for Randomness!: " + string.Join(",", weights));
                    //Console.ReadKey();
                }
            }
        }
        

        public static double sigmoid(double x)      //sigmoid squashing function
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public static double sigmoidDerivative(double x)
        {
            return sigmoid(x) * (1 - sigmoid(x));
        }
        
        //run the ANN for a specified number of iterations, and calculate the accuracy.
        //if we are in training mode, use the training data set and perform back-propagation.
        //if we are in testing mode, use the testing data set, no back-propagation
        public void run(Boolean isTraining, int iterations)
        {
            int[][] rawInputs;
            rawInputs = isTraining ? trainingsetRawInputs : testingsetRawInputs;

            double accuracy;
            for (int h = 0; h < iterations; h++)
            {
                if (isTraining)
                {
                    Console.WriteLine("Running Iteration " + h);
                }
                accuracy = runOneEpoch(isTraining, ref rawInputs);
                Console.WriteLine("Neural net's accuracy: " + accuracy);
            }
            Console.WriteLine("Done.");
        }

        //runs the ANN for one iteration on a set of data.   
        //if we are in training mode, perform back-propagation.
        //returns the accuracy of the ANN on the data.
        public double runOneEpoch(Boolean isTraining, ref int [][] rawInputs)
        {
            int rightCounter = 0;
            for (int i = 0; i < rawInputs.Length; i++)
            {
                InitInputs(i, rawInputs);
                FeedForward();
                calcErrors();
                if (getANNresult() == inputValue)
                    rightCounter++;
                if (isTraining)
                {
                    backPropagation();
                }
            }
            double accuracy = rightCounter / (double)rawInputs.Length;
            return accuracy;
        }

        //batchRun: runs the neural net repeatedly to generate data for the graphs.

        //0) run without training to find initial accuracy with training set and test set
        //1) train the neural net for specified number of iterations
        //2) run without training to find the accuracy with training set
        //3) run without training to find the accuracy with test set
        //4) repeat steps 1-3 10 times.
        //returns false if there was a problem loading the files.          
        public Boolean batchRun(int iterations)
        {
            double accuracy;
            int counter;

            accuracy = runOneEpoch(false, ref trainingsetRawInputs);
            Console.WriteLine("Initial training set accuracy: " + accuracy);
            accuracy = runOneEpoch(false, ref testingsetRawInputs);
            Console.WriteLine("Initial testing set accuracy: " + accuracy);
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < iterations; j++)
                {
                    runOneEpoch(true, ref trainingsetRawInputs);
                }
                counter = iterations * (i + 1);
                accuracy = runOneEpoch(false, ref trainingsetRawInputs);
                Console.WriteLine("Training set accuracy after: " + counter + " epochs: " + accuracy);
                accuracy = runOneEpoch(false, ref testingsetRawInputs);
                Console.WriteLine("Testing set accuracy after: " + counter + " epochs: " + accuracy);
            }
            Console.WriteLine("Done.");
            return true;
        }

    
        public void calcErrors()
        {
            for (int i = 0; i < NUM_DIGITS; i++)
            {
                if (i == inputValue)
                {
                    error[i] = 1 - layers[numLayers - 1].nodes[i].gx;
                }
                else
                {
                    error[i] = 0 - layers[numLayers - 1].nodes[i].gx;
                }
            }
        }

        //return the digit that the ANN thinks the input is.
        public int getANNresult()
        {
            int result = 0;
            double max = layers[numLayers - 1].nodes[0].fx;

            for (int i = 1; i < NUM_DIGITS; i++)
            {
                //whichever output is highest = the digit detected.  (could also use more complex threshold function)
                if (layers[numLayers - 1].nodes[i].fx > max)
                {
                    max = layers[numLayers - 1].nodes[i].fx;
                    result = i;
                }
            }
            return result;
        }

        /*
        //is the ANN correct?
        public Boolean isANNCorrect() {
            if (getANNresult() == inputValue) //neural net guessed the value of the digit correctly.
                return true;
            else
                return false;
        }
        */

        //get 1 input from the rawInputs array, normalize it, and store it in the inputs array.
        public void InitInputs(int index, int [][] rawInputs)
        {
            inputs = new double[NUM_BITS];

            inputValue = rawInputs[index][NUM_BITS];    //last bit in rawInputs stores what digit it is supposed to be
            for (int i = 0; i < NUM_BITS; i++)
            {
                inputs[i] = rawInputs[index][i] / (double)MAX_VAL;  //scale value range to 0 - 1.  
            }
            //Console.WriteLine(string.Join(",", inputs));
        }
        

        public void FeedForward()
        {
            double sum;

            //first handle layer[0], which reads from the inputs.
            for (int j = 0; j < layers[0].numNodes; j++)    //for each node in the layer
            {
                sum = 0;
                for (int k = 0; k < layers[0].numBackConnections; k++)      //for each connection to the node
                {
                    sum += inputs[k] * layers[0].nodes[j].weights[k];       //sum += input[0-64] * weight[0-64].
                }
                sum += layers[0].nodes[j].biasWeight;                       //add in bias node contribution

                layers[0].nodes[j].fx = sum;
                layers[0].nodes[j].gx = NeuralNetwork.sigmoid(sum);           //run it through sigmoid squashing function
            }

            //for each subsequent layer, sum the weights*inputs from the previous layer.           
            for (int i = 1; i < numLayers; i++)
            {
                for (int j = 0; j < layers[i].numNodes; j++)    //for each node in the layer
                {
                    sum = 0;
                    for (int k = 0; k < layers[i].numBackConnections; k++)      //for each connection to this node
                    {
                        sum += layers[i - 1].nodes[k].gx * layers[i].nodes[j].weights[k];
                    }
                    sum += layers[i].nodes[j].biasWeight;                       //add in bias node contribution

                    layers[i].nodes[j].fx = sum;
                    layers[i].nodes[j].gx = NeuralNetwork.sigmoid(sum);           //run it through sigmoid squashing function
                }
            }
        }

        public void backPropagation()
        {
            //first, lets calculate the outputWeights layer back-propagation (weights feeding into the 10 outputs)
            for (int i = 0; i < layers[numLayers-1].numNodes; i++)        //for each node in the output layer,
            {
                layers[numLayers-1].nodes[i].delta = error[i] * sigmoidDerivative(layers[numLayers-1].nodes[i].fx);
            }

            //now calculate the back-propagation for the intermediate hidden layers
            for (int h = numLayers-2; h >= 0; h--)                //for each layer h (excluding the output layer)
            {
                for (int i = 0; i < layers[h].numNodes; i++)        //for each node i in the layer h,
                {
                    double sumErrorWeightsTerm = 0;

                    for (int j = 0; j < layers[h+1].numNodes; j++)      //sum next-layer-deltas*weights-to-this-layer
                    {
                        sumErrorWeightsTerm += layers[h+1].nodes[j].delta * layers[h+1].nodes[j].weights[i];
                    }

                    layers[h].nodes[i].delta = sumErrorWeightsTerm * sigmoidDerivative(layers[h].nodes[i].fx);
                }
            }


            //apply the changes.
            double updateTerm;

            //now apply changes to the weights to output and intermediate layers
            for (int h = 1; h < numLayers; h++)   //for each layer h (excluding layer 0)
            {
                for (int i = 0; i < layers[h].numNodes; i++)  //for each node i in the layer h,
                {
                    for (int j = 0; j < layers[h].numBackConnections; j++)   //for each weight j to the node i in the layer h,
                    {
                        updateTerm = ALPHA * layers[h-1].nodes[j].gx * layers[h].nodes[i].delta;
                        layers[h].nodes[i].weights[j] += updateTerm;                    
                    }
                    layers[h].nodes[i].biasWeight += ALPHA * 1 * layers[h].nodes[i].delta; //update node's connection to bias
                }
            }

            //do layer[0], which interfaces with the input layer:
            for (int i = 0; i < layers[0].numNodes; i++)  //for each node i in layer 0,
            {
                for (int j = 0; j < layers[0].numBackConnections; j++)   //for each weight j to the node i in layer 0,
                {
                    updateTerm = ALPHA * inputs[j] * layers[0].nodes[i].delta; 
                    layers[0].nodes[i].weights[j] += updateTerm;
                }
                layers[0].nodes[i].biasWeight += ALPHA * 1 * layers[0].nodes[i].delta; //update node's connection to bias
            }
        }

        //set up the ANN layers.
        //note that we also create an Output Layer in addition to the hidden layers specified by the user.
        public void CreateLayers()
        {
            int numNodes = 0;
            int numPrevNodes = 0;
            numLayers = formObj.dataGridView1.Rows.Count;                 
            layers = new Layer[numLayers];

            for (int i = 0; i < numLayers; i++)
            {
                if (i != numLayers - 1)  //output layer will be handled differently.
                { 

                    if (formObj.dataGridView1.Rows[i].Cells["Nodes"].Value != null)
                        int.TryParse(formObj.dataGridView1.Rows[i].Cells["Nodes"].Value.ToString(), out numNodes);
                    else
                    {
                        Console.WriteLine("Error detected: trying to create neural net layer with 0 nodes.");
                    }

                    if (i == 0)  //first layer: layer 0.
                    {
                        numPrevNodes = NUM_BITS;    //layer 0 connects to each of NUM_BITS inputs. 
                    }
                    else //if (i < numLayers - 1)
                    {                        
                        numPrevNodes = layers[i - 1].nodes.Length;  //number of back-connections = number of nodes in previous layer.
                    }
                    
                }
                else //the output layer (layer[numLayers-1])
                {
                    numNodes = NUM_DIGITS;
                    numPrevNodes = layers[i - 1].nodes.Length;      //number of back-connections = number of nodes in previous layer.
                }
                layers[i] = new Layer(numNodes, numPrevNodes);
                if (i != numLayers - 1) 
                    Console.WriteLine("Layer " + i + " with " + numNodes + " nodes created.  Each node has " + numPrevNodes + " back-connections.");
                else
                    Console.WriteLine("Output layer with " + numNodes + " nodes created.  Each node has " + numPrevNodes + " back-connections.");
            }

            //init the error array
            error = new double[NUM_DIGITS];

        }


        //load all the digits from the file into the rawInputs array.
        //returns false if there was a problem loading from the file, returns true otherwise.
        public bool LoadInputsFromFile(string filename, ref int[][] rawInputs)
        {
            Boolean loadSuccess = true;
            System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.File.OpenRead(filename));  //open as read-only.

            //first get the number of lines in the file.
            int lineCount = System.IO.File.ReadLines(filename).Count();               

            //create the input array.
            rawInputs = new int[lineCount][];

            string lineOfText;
            int i = 0;
            while ((lineOfText = sr.ReadLine()) != null)
            {
                string[] values = lineOfText.Split(',');
                rawInputs[i] = Array.ConvertAll(values, int.Parse);

                if (rawInputs[i].Length != NUM_BITS + 1)
                { 
                    loadSuccess = false;
                    Console.WriteLine("Error reading a digit from the file.  Invalid number of bits detected.");
                    break;
                }

                i++;
            }
            Console.WriteLine(i + " digits read.");

            sr.Close();
            return loadSuccess;
        }
    }
}
