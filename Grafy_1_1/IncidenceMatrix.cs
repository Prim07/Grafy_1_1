using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Grafy_1_1
{
    class IncidenceMatrix
    {
        // Brzydkoszybka enkapsulacja
        public int[,] IncidenceArray;

        public IncidenceMatrix(AdjacencyMatrix sourceMatrix)
        {
            int num_v = sourceMatrix.AdjacencyArray.GetLength(1);
            int num_e = 0;

            // Zliczanie liczby wierzcholkow w macierzy sasiedztwa
            for (int i = 0; i < num_v; i++)
                for (int j = i + 1; j < num_v; j++)
                    if (sourceMatrix.AdjacencyArray[i, j] == 1)
                        num_e++;

            IncidenceArray = new int[num_v, num_e];

            // Zerowanie macierzy incydencji
            for (int i = 0; i < num_v; i++)
                for (int j = 0; j < num_e; j++)
                    IncidenceArray[i, j] = 0;


            int k = 0;

            // Konwersja Macierzy sąsiedztwa -> incydencji
            for (int i = 0; i < num_v; i++)
                for (int j = i + 1; j < num_v; j++)
                    if (sourceMatrix.AdjacencyArray[i, j] == 1)
                    {
                        IncidenceArray[i, k] = -1;
                        IncidenceArray[j, k] = 1;
                        k++;
                    }

        }

        public void Display(StackPanel StackPanelForDisplayingIncidenceMatrix, StackPanel StackPanelForDisplayingAdjacencylist)
        {
            StackPanelForDisplayingIncidenceMatrix.Children.Clear();

            string myString = "";

            for (int i = 0; i < IncidenceArray.GetLength(0); i++)
            {
                for (int j = 0; j < IncidenceArray.GetLength(1); j++)
                {
                    myString += IncidenceArray[i, j].ToString() + "  ";
                }
                myString += "\n";
            }

            TextBlock myBlock = new TextBlock();
            myBlock.Text = myString;
            myBlock.FontSize = 16;
            StackPanelForDisplayingIncidenceMatrix.Children.Add(myBlock);

            // Nowa lista sąsiedztwa
            AdjacencyList adjacencyList = new AdjacencyList(this);
            adjacencyList.Display(StackPanelForDisplayingAdjacencylist);

        }

    }
}
