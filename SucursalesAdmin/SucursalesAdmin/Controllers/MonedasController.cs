using DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SucursalesAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        private MyDbContext _context;

        public MonedasController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IEnumerable<Moneda> GetMonedas() => _context.Monedas.ToList();
    }
}
