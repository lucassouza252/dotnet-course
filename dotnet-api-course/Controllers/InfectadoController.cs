using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult EditarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            var encontrado = Builders<Infectado>.Filter.Eq("DataNascimento", dto.DataNascimento);
            var update = Builders<Infectado>.Update.Set("Sexo", infectado.Sexo);

            _infectadosCollection.UpdateOne(encontrado, update);
            
            return StatusCode(200, "Infectado editado com sucesso");
        }

         [HttpDelete]
        public ActionResult DeletarInfectado([FromBody] InfectadoDto dto)
        {
        
            var encontrado = Builders<Infectado>.Filter.Eq("DataNascimento", dto.DataNascimento);
            _infectadosCollection.DeleteOne(encontrado);
            
            return StatusCode(200, "Infectado deletado com sucesso");
        }

    }
}
