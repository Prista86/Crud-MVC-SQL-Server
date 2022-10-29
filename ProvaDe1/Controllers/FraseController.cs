using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ProvaDe1.DB.Entities;
using ProvaDe1.DB;
using ProvaDe1.Models;

namespace ProvaDe1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraseController : ControllerBase
    {
        private readonly Repository repository;
        public FraseController(Repository repository)
        {
            this.repository = repository;
        }

        // POST api/<PersonController>
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] Frase frase)
        {
            if (frase != null)
            {
                frase.Testo = frase.Testo + " NEW";
                
            }
            return Ok(frase);
        }

        [HttpPost("InsertFrase")]
        public async Task<IActionResult> InsertPerson([FromBody] FraseModel model)
        {
            Frase frase = new Frase();
            frase.Testo = model.Testo;            
            this.repository.InsertFrase(frase);
            return Ok(200);
        }

        [HttpPost("UpdateFrase")]
        public async Task<IActionResult> UpdateFrase([FromBody] FraseModel model)
        {
            Frase frase = new Frase();
            frase.ID = System.Guid.Parse(model.ID);
            frase.Testo = model.Testo;            
            this.repository.UpdateFrase(frase);
            return Ok(200);
        }

        [HttpPost("DeleteFrase")]
        public async Task<IActionResult> DeleteFrase([FromBody] FraseModel model)
        {
            this.repository.DeleteFrase(model.ID);
            return Ok(200);
        }
    }
}
