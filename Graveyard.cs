using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml.Linq;


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
                graveyard[Int32.Parse(info[0]), Int32.Parse(info[1])] = new DeadAnimal(info[2], info[3], info[4]);

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
        private int checkDate(String date)
        {
            DateTime datetime = DateTime.Now;
            String currentTime = datetime.ToString("MM/dd/yyyy");
            String[] tmp = currentTime.Split("/");
            try
            {
                String[] userDate = Regex.Split(date, @"/|-");
                if (Int32.Parse(userDate[0]) <= 12)
                {
                    if (Int32.Parse(userDate[1]) <= 31)
                    {
                        if (Int32.Parse(userDate[2]) <= Int32.Parse(tmp[2]))
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (FormatException)
            {
                return -3;
            }
            return -1;
        }
        public int SetNewAnimal(int col, int row, String name, String date, String tipo)
        {
            if(checkDate(date) != 0)    return checkDate(date);
            if(checkPos(col,row) != 0)  return -2;
            if(checkValidName(name) != 0) return -4;
            if(checkValidType(tipo) != 0) return -5;
            crud.Insert(col, row, name, date, tipo);
            return 0;
        }

        private int checkValidType(string tipo)
        {
            if(tipo == "null" || tipo == "NULL" || tipo.Length == 0) return -5;
            return 0;
        }

        private int checkValidName(String name)
        {
            if (name == "null" || name == "NULL"|| name.Length == 0) return -4;
            return 0;
        }

        private int checkPos(int col, int row)
        {
            if (graveyard[col,row] == null)
            {
                return 0; //Posizione libera
            }
            return -1;
        }
    }

}

