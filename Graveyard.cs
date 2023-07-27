using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CompitiVacanze
{
    public class Graveyard
    {
        [JsonInclude]
        public DeadAnimal[,] graveyard = new DeadAnimal[10, 10];
        Random random = new Random();
        public String createGUI()
        {
            String gui = String.Empty;
            int len = graveyard.GetLength(0);
            for (int i = 0; len > i; i++)
            {
                gui += "| ";
                for (int j = 0; j < len; j++)
                {
                    switch (graveyard[i, j])
                    {
                        case null:
                            gui += " 0 ";
                            break;

                        case DeadAnimal:
                            gui += " X ";
                            break;
                    }
                    gui += " | ";
                }
                gui += "\n";
            }
            return gui;
        }
        public void populate()
        {
            int len = graveyard.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    graveyard[i, j] = null;
                }
            }
        }
        public Graveyard()
        {
            if(graveyard == null)
            {
                Console.WriteLine("Il cimitero è null");
                populate();
            }
            else
            {
                Console.WriteLine("Il cimitero non è null");
                return;
            }
        }
        public void showGraveyard()
        {
            Console.Clear();
            for(int i = 0;i < graveyard.GetLength(0); i++)
            {
                for (int j = 0; j < graveyard.GetLength(1); j++)
                {
                    Console.WriteLine("Col: " + i + "\nRow: " + j + "\nAnimal: " + graveyard[i, j]);
                }
            }
        }
        public string ToJson() { return JsonConvert.SerializeObject(graveyard,Formatting.Indented); }
        public String SetNewAnimal(int col, int row, String name, String date, String tipo)
        {
            DeadAnimal[,] relay = graveyard;
            if (relay[col,row] == null)
            {
                relay[col, row] = new DeadAnimal(random.Next(100), name, date, tipo);
                this.graveyard = relay;
                Console.WriteLine(this.createGUI());
                return JsonConvert.SerializeObject(relay[col, row]);
            }
            else
            {
                return "Cella occupata";
            }
        }
    }

}

