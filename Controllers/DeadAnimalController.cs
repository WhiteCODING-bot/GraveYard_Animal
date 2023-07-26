using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompitiVacanze.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DeadAnimalController: ControllerBase
    {
        DeadAnimal deadAnimal = new DeadAnimal();
        Graveyard graveyard = new Graveyard();

        private readonly ILogger<DeadAnimalController> _logger;

        public DeadAnimalController(ILogger<DeadAnimalController> logger)
        {
            //PER TESTING
            deadAnimal.SetName("Fufi");
            deadAnimal.SetDate("07/04/23");
            deadAnimal.SetType("Cane");
            //FINE SEZIONE TEST
            _logger = logger;
        }

        //TUTTE LE GET

        [HttpGet(Name = "Name")]
        public string GetName() => deadAnimal.GetName();

        [HttpGet(Name = "Date")]
        public String GetDate() => deadAnimal.GetDate();

        [HttpGet(Name = "Type")]
        public String GetType() => deadAnimal.GetAnimal();

        [HttpGet("{id}")]
        public String GetAnimal(int id) => deadAnimal.GetById(id);

        [HttpGet(Name = "Graveyard")]
        public String GetGraveyard() => graveyard.createGUI();

    }
}