using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4___neural_net
{
    public partial class Form1 : Form
    {
        //DataTable table;
        NeuralNetwork neuralNet;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Application.StartupPath;

            //DigitView.initDigitView();

            //dataGridView1.Da
            //DataTable table = new DataTable();
            dataGridView1.Rows.Add(0, 100);

            neuralNet = new NeuralNetwork();
            neuralNet.formObj = this;



        }

        private void NextImageBtn_Click(object sender, EventArgs e)
        {
            if (DigitView.digitFileName == null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (DigitView.LoadDigitFromFile(openFileDialog1.FileName))
                    {
                        DrawDigit(DigitView.inputDigit);
                    }
                }
            }
            else
            {
                if (DigitView.LoadDigitFromFile(openFileDialog1.FileName))
                {
                    DrawDigit(DigitView.inputDigit);
                }
            }
        }

        public void DrawDigit(int [] digitArray)
        {
            const int IMAGESIZE = 200;
            int bitSize = IMAGESIZE / 8;
            int grayScale = 0;
            Color grayScaleColor;
            SolidBrush brush;

            Bitmap digitBmp = new Bitmap(IMAGESIZE, IMAGESIZE);
            Graphics digitGraphics = Graphics.FromImage(digitBmp);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //SolidBrush brush = new SolidBrush(Color)

                    // 0 is fully transparent, and 255 is fully opaque
                    grayScale = Convert.ToInt32((digitArray[i * 8 + j] / (double)16) * 255);
                    grayScaleColor = Color.FromArgb(grayScale, Color.Black);
                    brush = new SolidBrush(grayScaleColor);                    
                    digitGraphics.FillRectangle(brush, j * bitSize, i * bitSize, bitSize, bitSize);
                }

            }
            pictureBox1.Image = digitBmp;

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Layer"].Value = dataGridView1.Rows.Count - 1;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Layer"].Value = i;
            }
        }

        private void trainingModeBtn_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = trainingModeBtn.Checked;
            numericUpDown2.Enabled = trainingModeBtn.Checked;
            label1.Enabled = trainingModeBtn.Checked;
            label2.Enabled = trainingModeBtn.Checked;
        }

        private void CreateNeuralNetBtn_Click(object sender, EventArgs e)
        {
            neuralNet.CreateLayers();
            LoadTrainingFileBtn.Enabled = true;

        }

        private void LoadTrainingFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (neuralNet.LoadInputsFromFile(openFileDialog1.FileName, ref neuralNet.trainingsetRawInputs))
                {
                    LoadTestingFileBtn.Enabled = true;
                }
            }                      
        }

        private void LoadTestingFileBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (neuralNet.LoadInputsFromFile(openFileDialog1.FileName, ref neuralNet.testingsetRawInputs))
                {
                    groupBoxPlayer1Type.Enabled = true;
                    RunBtn.Enabled = true;
                    BatchRunBtn.Enabled = true;
                }
            }
        }


        private void RunBtn_Click(object sender, EventArgs e)
        {
            //pass in whether it is in training mode, and the number of iterations for training mode.
            int iterations;
            if (!trainingModeBtn.Checked)
            {
                iterations = 1; //for testing mode, only do 1 iteration.
            }
            else
            {
                NeuralNetwork.ALPHA = (double)numericUpDown2.Value;
                Console.WriteLine("Alpha: " + NeuralNetwork.ALPHA);
                iterations = (int)numericUpDown1.Value;
            }

            neuralNet.run(trainingModeBtn.Checked, iterations);
            
        }

        private void BatchRunBtn_Click(object sender, EventArgs e)
        {
            NeuralNetwork.ALPHA = (double)numericUpDown2.Value;
            Console.WriteLine("Alpha: " + NeuralNetwork.ALPHA);
            int iterations = (int)numericUpDown1.Value;
            neuralNet.batchRun(iterations);
        }
    }
}
