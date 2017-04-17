using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Grafy_1_1
{
    class AdjacencyList
    {
        //Brzydkoszybka enkapsulacja
        //n list gdzie n to liczba wierzchołków
        //public List<int>[] ArrayOfLists;
        public List<List<int>> ListOfLists;

        public AdjacencyList(IncidenceMatrix sourceMatrix)
        {

            // Pobranie liczby krawędzi i wierzchołków
            int num_e = sourceMatrix.IncidenceArray.GetLength(1);
            int num_v = sourceMatrix.IncidenceArray.GetLength(0);

            // Zmienne pomocnicze
            int tmp1 = 0, tmp2 = 0;

            // Alkokowanei pamięci pod listę list
            ListOfLists = new List<List<int>>();

            // Czyścimy wszystkie listy w tablicy
            for (int i = 0; i < num_v; i++)
                ListOfLists.Add(new List<int>());

            //Konwersja Macierzy Incydencji -> Lista sąsiedztwa
            for (int j = 0; j < num_e; j++)
            {
                for (int i = 0; i < num_v; i++)
                {
                    if (sourceMatrix.IncidenceArray[i, j] == 1)
                        tmp2 = i;
                    else if (sourceMatrix.IncidenceArray[i, j] == -1)
                        tmp1 = i;
                }
                ListOfLists[tmp2].Add(tmp1 + 1);
                ListOfLists[tmp1].Add(tmp2 + 1);
            }
            
        }

        public void Display(StackPanel StackPanelForDisplayingAdjacencyList)
        {
            StackPanelForDisplayingAdjacencyList.Children.Clear();

            string myString = "";

            for (int i = 0; i < ListOfLists.Count; i++)
            {
                myString += (i+1).ToString();
                for (int j = 0; j < ListOfLists[i].Count; j++)
                {
                    myString += " → " +  ListOfLists[i][j].ToString();
                }
                myString += " ↴\n";
            }

            TextBlock myBlock = new TextBlock();
            myBlock.Text = myString;
            myBlock.FontSize = 16;
            StackPanelForDisplayingAdjacencyList.Children.Add(myBlock);
        }
    }
}
