using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int Id)
        {
            bool exists = _context.CelestialObjects.Any(i => i.Id == Id);
            if (exists == false)
            {
                return NotFound();
            }
            CelestialObject co = new CelestialObject();
            
            return Ok(Id);
        }
    }
}
