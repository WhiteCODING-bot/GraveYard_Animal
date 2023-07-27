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
        public Graveyard()
        {
            int len  = graveyard.GetLength(0);
            for(int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    graveyard[i, j] = null;
                }
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
            if (this.graveyard[col,row] == null)
            {
                this.graveyard[col, row] = new DeadAnimal(random.Next(100), name, date, tipo);
                Console.WriteLine(this.createGUI());
                return JsonConvert.SerializeObject(this.graveyard[col, row]);
            }
            else
            {
                return "Cella occupata";
            }
        }
    }

}

