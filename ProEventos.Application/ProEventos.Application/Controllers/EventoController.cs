using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Data;
using ProEventos.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos.ToList(); 
        }
        [HttpGet("{id}")]
        public Evento GetByID(int id)
        {
            return _context.Eventos.FirstOrDefault(x => x.EventoID == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de put com o id: {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de delete com o id: {id}";
        }
    }
}
