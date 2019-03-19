using System;

namespace KohonenNetwork
{
    class Neuron
    {
        private int x;
        private int y;
        public double R_weight;
        public double G_weight;
        public double B_weight;
        public int groupID;

        public Neuron(int x, int y, int R, int G, int B)
        {
            this.x = x;
            this.y = y;
            Random weight = new Random(23);
            R_weight = R;
            G_weight = G;
            B_weight = B;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }


        //METODY MATEMATYCZNE
        public double CheckDistance(Vector input)
        {
            double distance = 0;

            distance += Math.Pow(input.red - R_weight, 2) + Math.Pow(input.green - G_weight, 2) + Math.Pow(input.blue - B_weight, 2);

            return Math.Sqrt(distance);
        }

        public void SnackForNode(Vector input, double LR_INF)
        {
            R_weight += LR_INF * (input.red - R_weight);
            G_weight += LR_INF * (input.green - G_weight);
            B_weight += LR_INF * (input.blue - B_weight);
        }


    }
}
