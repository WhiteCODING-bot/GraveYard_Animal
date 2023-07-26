using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompitiVacanze
{
    public class DeadAnimal
    {
        [JsonInclude]
        public int id = 0;
        [JsonInclude]
        public String name;
        [JsonInclude]
        public String date;
        [JsonInclude]
        public String type;
        public int GetId() { return id; }
        public String GetName() { return name; }
        public String GetDate() { return date; }
        public String GetAnimal() { return type; }
        public String GetById(int id)
        {
            Graveyard grave = new Graveyard();
            object[,] tmp = (object[,])JsonConvert.DeserializeObject(grave.ToJson());
            for(int i = 0; i< tmp.Length; i++)
            {
                for(int j = 0; j < tmp.Length; j++)
                {
                    DeadAnimal deadAnimal = (DeadAnimal)tmp[i, j];
                    if(deadAnimal.GetId() == id)
                    {
                        return JsonConvert.SerializeObject(deadAnimal);
                    }
                }
            }
            return "Non trovato";
        }

        public void SetId(int id) {this.id = id; }
        public void SetName(String name) {this.name = name; }
        public void SetDate(String date) {this.date = date; }
        public void SetType(String type) { this.type = type; }


        public DeadAnimal(){    }

        public DeadAnimal(int id, string name, string date, string type)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.type = type;
        }

        public string ToJson() { return JsonConvert.SerializeObject(this); }
    }
}