using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/Students
        /*        [HttpGet]
                public string GetStudent(string orderBy)
                {
                    return $"Kowalski, Geteralski, Kondrat sortowanie={orderBy}";
                }*/

        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());

        }



        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");

            }
            else if (id == 2)
            {
                return Ok("Geteralski");
            }
            else if (id == 2)
            {
                return Ok("fofofof");
            }

            return NotFound("Nie ma studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Actualiz(int id)
        {
            return Ok(" Ąktualizacja dokończona");

        }

        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            return Ok(" Usuwanie ukończone");

        }

    }
}
