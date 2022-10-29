using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaDe1.DB;
using ProvaDe1.DB.Entities;
using ProvaDe1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaDe1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository repository;

        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Frasi()
        {
            List<Frase> frasi = this.repository.GetPersons();
            List<FraseModel> model = new List<FraseModel>();
            foreach (Frase p in frasi)
                model.Add(new FraseModel()
                {
                    Testo = p.Testo,                    
                }); ;
            return View(model);
        }
        public IActionResult InsertFrase()
        {           
            return View();
        }
        public IActionResult UpdateFrase()
        {
            List<Frase> frasi = this.repository.GetPersons();
            List<FraseModel> model = new List<FraseModel>();
            foreach (Frase p in frasi)
                model.Add(new FraseModel()
                {
                    ID = p.ID.ToString(),
                    Testo = p.Testo,
                    
                });
            return View(model);
        }
        public IActionResult DeleteFrase()
        {
            List<Frase> frasi = this.repository.GetPersons();
            List<FraseModel> model = new List<FraseModel>();
            foreach (Frase p in frasi)
                model.Add(new FraseModel()
                {
                    ID = p.ID.ToString(),
                    Testo = p.Testo,
                    
                });
            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
