using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KohonenNetwork
{
    public partial class Main : Form
    {
        //Parameters for SOM
        public double learningRate = 0.1;
        public static int neighbourhood = 24;
        private int maxIteration = 1000;
        //Variables used in algorithm
        private List<Vector> inputList = new List<Vector>();
        private List<Neuron> neuronList = new List<Neuron>();
        List<Neuron> neuronListCopy = new List<Neuron>();

        private int[,] neuronPosition = new int[50, 50];

        bool isMapWorking = false;
        int numberOfIterations = 0;
        public double neighbourhoodPrecise = neighbourhood;
        int groupAmount = 0;

        public Main()
        {
            InitializeComponent();
            text_iterations.Text = maxIteration.ToString();
            text_learning.Text = learningRate.ToString();
            text_neigh.Text = neighbourhood.ToString();
            neighbourLabel.Text = "-";
            learningLabel.Text = "-";
            nr_iteracji.Text = "-";
        }

        //Updates MetaData on screen
        private void UpdateMeta()
        {
            learningLabel.Text = Math.Round(learningRate, 4).ToString();
            neighbourLabel.Text = Math.Round(neighbourhoodPrecise).ToString();
            nr_iteracji.Text = (numberOfIterations-1).ToString();
        }

        //Generates neurons
        private void GenerateNeurons()
        {
            neuronList.Clear();
            Random rand = new Random(23154846);

            int Rweight = 1;
            int Gweight = 1;
            int Bweight = rand.Next(0, 255);
            int x = 0;

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Rweight = rand.Next(0, 255);
                    Gweight = rand.Next(0, 255);
                    Bweight = rand.Next(0, 255);

                    neuronPosition[i, j] = x++;
                    neuronList.Add(new Neuron(j, i, Rweight, Gweight, Bweight));
                }
            }
        }

        //Generates random input values
        private void GenerateInput()
        {
            inputList.Clear();
            Random rand = new Random();
            int Rweight = 1;
            int Gweight = 1;
            int Bweight = rand.Next(0, 255); ;
            int x = 0;
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Rweight = (Bweight + Rweight * x + x) % 255;
                    Gweight = (Rweight + Gweight * x / (x + 1)) % 255;
                    Bweight = (Gweight + Bweight * x / (x + 3)) % 255;
                    inputList.Add(new Vector(Rweight, Gweight, Bweight));

                    x++;
                }
            }

        }

        //Draws initial weights on nodes map
        private void DrawMapInit()
        {
            int red;
            int green;
            int blue;

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    red = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).R_weight);
                    green = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).G_weight);
                    blue = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).B_weight);

                    SolidBrush myBrush = new SolidBrush(Color.FromArgb(red, green, blue));
                    CreateGraphics().FillRectangle(myBrush, new Rectangle(30 + (10 * i), 30 + (10 * j), 10, 10));
                }
            }
        }

        //Updates Map
        private void UpdateMap(int x, int y)
        {
            int red;
            int green;
            int blue;

            int i = x - neighbourhood;
            if (i < 0) i = 0;

            int ii = x + neighbourhood;
            if (ii > 50) ii = 50;

            int kj = y - neighbourhood;
            if (kj < 0) kj = 0;

            int jj = y + neighbourhood;
            if (jj > 50) jj = 50;

            for (i += 0; i < ii; i++)
            {
                for (int j = kj; j < jj; j++)
                {
                    red = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).R_weight);
                    green = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).G_weight);
                    blue = Convert.ToInt32(neuronList.ElementAt(neuronPosition[i, j]).B_weight);

                    SolidBrush myBrush = new SolidBrush(Color.FromArgb(red, green, blue));
                    CreateGraphics().FillRectangle(myBrush, new Rectangle(30 + (10 * i), 30 + (10 * j), 10, 10));
                }
            }
        }

        //Returns index of input
        private int PickRandomInput()
        {
            Random index = new Random();
            int input = index.Next(0, 2499);
            return input;
        }

        //Returns index of winner node
        private int WinnerOfIteration(Vector input)
        {
            int id = 0;
            int x;
            int y;
            double distance;
            double activeWinner = 999999;
            foreach (Neuron neuron in neuronList)
            {
                distance = neuron.CheckDistance(input);
                if (activeWinner > distance)
                {
                    activeWinner = distance;
                    x = neuron.GetX();
                    y = neuron.GetY();
                    id = neuronPosition[x, y];
                }
            }
            return id;
        }

        //Modifies neurons weights
        private void GiveSnacks(int winner, Vector inputVector)
        {
            int x = neuronList.ElementAt(winner).GetX();
            int y = neuronList.ElementAt(winner).GetY();
            int i = x - neighbourhood;
            int ii = x + neighbourhood;
            int jTemp = y - neighbourhood;
            int jj = y + neighbourhood;

            if (i < 0) i = 0;
            if (ii > 50) ii = 50;
            if (jTemp < 0) jTemp = 0;
            if (jj > 50) jj = 50;

            for (i += 0; i < ii; i++)
            {
                for (int j = jTemp; j < jj; j++)
                {
                    double LR_INF = learningRate * CalculateInfluence(x, y, i, j);
                    neuronList.ElementAt(neuronPosition[i, j]).SnackForNode(inputVector, LR_INF);
                }
            }
        }

        //Decays neghbourhood range
        public void NeighbourhoodDecay()
        {
            neighbourhoodPrecise = (double)neighbourhood * Math.Exp(-(double)numberOfIterations / 2 / (double)maxIteration);
            neighbourhood = (int)Math.Ceiling(neighbourhoodPrecise);
        }

        //Decays learning rate
        public void LearningRateDecay()
        {
            learningRate *= Math.Exp(-(double)numberOfIterations / 55 / (double)maxIteration);

        }

        //Calculates influence on given neighbour Neuron
        public double CalculateInfluence(int winnerX, int winnerY, int idX, int idY)
        {
            double distX = winnerX - idX;
            double distY = winnerY - idY;
            double inf = -(((distX * distX) + (distY * distY))) / (2 * (neighbourhood * neighbourhood));

            return Math.Exp(inf);
        }

        //Iterate LOOP
        private void Iterations()
        {
            if (isMapWorking == false)
            {
                neuronListCopy = neuronList;
                return;
            }

            Vector inputVector = inputList.ElementAt(PickRandomInput());

            int winner = WinnerOfIteration(inputVector);

            GiveSnacks(winner, inputVector);

            UpdateMap(neuronList.ElementAt(winner).GetX(), neuronList.ElementAt(winner).GetY());

            LearningRateDecay();
            NeighbourhoodDecay();

            Thread iteration_number = new Thread(UpdateMeta);
            iteration_number.Start();
            if (numberOfIterations <= maxIteration)
            {
                numberOfIterations++;
                Iterations();
            }

           

            b_Kmeans.Enabled = true;
            neuronListCopy = neuronList;
        }

        private void b_start_Click(object sender, EventArgs e)
        {
            Thread iter = new Thread(Iterations);

            if (isMapWorking == true) isMapWorking = false;

            Thread.Sleep(150);


            if (text_learning.Text == "") return;
            if (text_neigh.Text == "") return;
            if (text_iterations.Text == "") return;


            GenerateInput();
            GenerateNeurons();
            DrawMapInit();

            Thread.Sleep(150);

            learningRate = Convert.ToDouble(text_learning.Text.Replace('.', ','));
            neighbourhood = Convert.ToInt32(text_neigh.Text);
            maxIteration = Convert.ToInt32(text_iterations.Text);
            numberOfIterations = 0;
            isMapWorking = true;
            iter.Start();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            isMapWorking = false;
            Thread.Sleep(150);
        }



        ///////////////////////////////////////////////////////////
        ///             KMEANS ALGORITHM METHODS                ///
        ///////////////////////////////////////////////////////////

        private void b_Kmeans_Click(object sender, EventArgs e)
        {

            try
            {
                groupAmount = Convert.ToInt32(text_groups.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podaj ilość grup");
                return;
            }
            try
            {
                //GENERATING CENTROIDS
                b_Kmeans.Enabled = false;
                int R;
                int G;
                int B;
                int seed;
                Kmeans groups = new Kmeans();
                Random rand = new Random();
                groups.clusters.Clear();
                for (int i = 0; i < Convert.ToInt32(text_groups.Text); i++)
                {
                    seed = rand.Next(0, 2499);
                    R = (int)neuronListCopy.ElementAt(seed).R_weight;
                    G = (int)neuronListCopy.ElementAt(seed).G_weight;
                    B = (int)neuronListCopy.ElementAt(seed).B_weight;
                    //Thread.Sleep(5);
                    groups.clusters.Add(new Vector(R, G, B));
                }

                for (int i = 0; i < 50; i++)
                {
                    SetClusters(neuronListCopy, groups);
                    UpdateCentroids(neuronListCopy, groups);
                }

                foreach (Neuron node in neuronListCopy)
                {
                    node.R_weight = groups.clusters.ElementAt(node.groupID).red;
                    node.G_weight = groups.clusters.ElementAt(node.groupID).green;
                    node.B_weight = groups.clusters.ElementAt(node.groupID).blue;
                }

                //DrawMapInit();
                DrawGroups(neuronListCopy);
            }
            catch (Exception ex)
            {
                b_Kmeans.Enabled = true;
                MessageBox.Show("ERROR");
            }
        }

        //Signs all neurons with closest groupCluster ID
        private void SetClusters(List<Neuron> neuronListCopy, Kmeans groups)
        {
            int groupID = 0;
            double currDistance = Double.MaxValue;
            foreach (Neuron node in neuronListCopy)
            {
                double minDistance = Double.MaxValue;

                for (int i = 0; i < groups.clusters.Count(); i++)
                {
                    currDistance = node.CheckDistance(groups.clusters.ElementAt(i));
                    if (minDistance > currDistance)
                    {
                        minDistance = currDistance;
                        groupID = i;
                    }
                }
                node.groupID = groupID;
            }
        }

        //Modifies cluster weights closer to assigned neurons
        private void UpdateCentroids(List<Neuron> neuronListCopy, Kmeans groups)
        {
            for (int i = 0; i < groups.clusters.Count(); i++)
            {
                int countNodes = 0;

                Vector meanVector = new Vector(0, 0, 0);

                foreach (Neuron node in neuronListCopy)
                {
                    if (node.groupID == i)
                    {
                        meanVector.red += Convert.ToInt32(node.R_weight);
                        meanVector.green += Convert.ToInt32(node.G_weight);
                        meanVector.blue += Convert.ToInt32(node.B_weight);

                        countNodes++;
                    }
                }
                meanVector.red = (int)Math.Round((double)meanVector.red / countNodes);
                meanVector.green = (int)Math.Round((double)meanVector.green / countNodes);
                meanVector.blue = (int)Math.Round((double)meanVector.blue / countNodes);

                groups.clusters.ElementAt(i).red += (int)Math.Round(0.1 * ((double)meanVector.red - (double)groups.clusters.ElementAt(i).red));
                groups.clusters.ElementAt(i).green += (int)Math.Round(0.1 * ((double)meanVector.green - (double)groups.clusters.ElementAt(i).green));
                groups.clusters.ElementAt(i).blue += (int)Math.Round(0.1 * ((double)meanVector.blue - (double)groups.clusters.ElementAt(i).blue));
            }
        }

        //Draws grouping result in new form
        private void DrawGroups(List<Neuron> neuronListCopy)
        {
            SelectedGroups wynik = new SelectedGroups();
            wynik.Show();
            int red;
            int green;
            int blue;

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    red = Convert.ToInt32(neuronListCopy.ElementAt(neuronPosition[i, j]).R_weight);
                    green = Convert.ToInt32(neuronListCopy.ElementAt(neuronPosition[i, j]).G_weight);
                    blue = Convert.ToInt32(neuronListCopy.ElementAt(neuronPosition[i, j]).B_weight);

                    SolidBrush myBrush = new SolidBrush(Color.FromArgb(red, green, blue));
                    wynik.CreateGraphics().FillRectangle(myBrush, new Rectangle(5 + (10 * i), 5 + (10 * j), 10, 10));
                }
            }


            
        }
    }
}
