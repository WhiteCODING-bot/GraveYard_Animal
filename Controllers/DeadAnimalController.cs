using Microsoft.AspNetCore.Mvc;

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
        public String SetAnimal(int col, int row, String name, String date, String tipo)
        {
            switch(graveyard.SetNewAnimal(col, row, name, date, tipo))
            {
                case 0:
                    return "Animale aggiunto";
                case -1:
                    return "Errore data\nRicontrollare";
                case -2:
                    return "Posizione Occupata\nSelezionare una nuova cella";
                case -3:
                    return "Errore di formattazione data\nRicontrollare";
                case -4:
                    return "Il Nome non può essere null\nRicontrollare";
                case -5:
                    return "Il tipo inserito non può essere null\nRicontrollare";
            }
            return "ok";
        }
        //TUTTE LE GET
        [HttpGet("{col},{row}")]
        public String GetAnimal(int col,int row) => deadAnimal.GetByPos(col,row);

        [HttpGet(Name = "Graveyard")]
        public String GetGraveyard() => graveyard.createGUI();

    }
}