using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CompitiVacanze
{
    public class DeadAnimal
    {
        [JsonInclude]
        public String name;
        [JsonInclude]
        public String date;
        [JsonInclude]
        public String type;
        public String GetName() { return name; }
        public String GetDate() { return date; }
        public String GetAnimal() { return type; }
        public String GetByPos(int col, int row)
        {
            Graveyard graveyard = new Graveyard();
            if(graveyard.graveyard[col,row] != null) return graveyard.graveyard[col,row].ToJson();
            return "Cella libera";
        }

        public void SetName(String name) {this.name = name; }
        public void SetDate(String date) {this.date = date; }
        public void SetType(String type) { this.type = type; }


        public DeadAnimal(){   }

        public DeadAnimal(string name, string date, string type)
        {
            this.name = name;
            this.date = date;
            this.type = type;
        }

        public string ToJson() { return JsonConvert.SerializeObject(this); }
    }
}