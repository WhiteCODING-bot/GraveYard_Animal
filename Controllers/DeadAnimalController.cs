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
        CRUD_GraveYard crud = new CRUD_GraveYard();
        private readonly ILogger<DeadAnimalController> _logger;

        public DeadAnimalController(ILogger<DeadAnimalController> logger)
        {
            
            _logger = logger;
        }


        [HttpPut]
        public void SetAnimal(int col, int row, String name, String date, String tipo) => graveyard.SetNewAnimal(col, row, name, date, tipo);
        
        //TUTTE LE GET
        [HttpGet("{col},{row}")]
        public String GetAnimal(int col,int row) => deadAnimal.GetById(col,row);

        [HttpGet(Name = "Graveyard")]
        public String GetGraveyard() => graveyard.createGUI();
        [HttpGet]
        public String[] GetAllInfo() => crud.SelectAll();
    
    }
}