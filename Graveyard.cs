using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CompitiVacanze
{
    public class Graveyard
    {
        [JsonInclude]
        public object[,] graveyard = new object[10, 10];
        public String createGUI()
        {
            String gui = "| ";
            int len  = graveyard.GetLength(0);
            for(int i = 0; len > i; i++)
            {
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
                gui += "\n| ";

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
            graveyard[0,0] = new DeadAnimal(0,"Francesco", "31/10/2022", "Serpente");
        }

        public string ToJson() { return JsonConvert.SerializeObject(graveyard,Formatting.Indented); }

    }

}

