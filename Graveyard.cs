using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CompitiVacanze
{
    public class Graveyard
    {
        CRUD_GraveYard crud = new CRUD_GraveYard();
        Random random = new Random();
        [JsonInclude]
        public DeadAnimal[,] graveyard = new DeadAnimal[10, 10];

        public String createGUI()
        {
            String gui = String.Empty;
            int len = graveyard.GetLength(0);
            for (int i = 0; len > i; i++)
            {
                gui += "| ";
                for (int j = 0; j < len; j++)
                {
                    if (graveyard[i,j] == null)
                    {
                        gui += " O ";
                    }
                    else
                    {
                        gui += " X ";
                    }
                    gui += " | ";
                }
                gui += "\n";
            }
            return gui;
        }

        public void populate()
        {
            CRUD_GraveYard crud = new CRUD_GraveYard();
            String[] tmp = crud.SelectAll();
            for(int i = 0; i < tmp.Length; i++)
            {
                String[] info = tmp[i].Split(",");
                graveyard[Int32.Parse(info[0]), Int32.Parse(info[1])] = new DeadAnimal(Int32.Parse(info[2]), info[3], info[4], info[5]);

            }
        }

        public Graveyard()
        {
            populate();
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
        public void SetNewAnimal(int col, int row, String name, String date, String tipo) => crud.Insert(col, row,random.Next(100), name, date, tipo);
    }

}

