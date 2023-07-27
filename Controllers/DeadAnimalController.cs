using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace CompitiVacanze.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class DeadAnimalController: ControllerBase
    {
        DeadAnimal deadAnimal = new DeadAnimal();
        Graveyard graveyard = new Graveyard();
        private SqliteConnection connection = new SqliteConnection("Data Source = graveyard.db");

        private readonly ILogger<DeadAnimalController> _logger;

        public DeadAnimalController(ILogger<DeadAnimalController> logger)
        {
            Console.WriteLine("Nuovo controller");
            _logger = logger;
        }


        [HttpPut]
        public String SetAnimal(int col, int row, String name, String date, String tipo) => graveyard.SetNewAnimal(col, row, name, date, tipo);
        
        //TUTTE LE GET
        [HttpGet("{id}")]
        public String GetAnimal(int id) => deadAnimal.GetById(id);

        [HttpGet(Name = "Graveyard")]
        public String GetGraveyard()
        {
            return graveyard.createGUI();
        }
    }
}