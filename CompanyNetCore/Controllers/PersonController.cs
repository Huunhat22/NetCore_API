using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyNetCore.Entities;

using Microsoft.AspNetCore.Mvc;

namespace CompanyNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDatabaseContext _context;

        public PersonController(PersonDatabaseContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var persons = _context.Persons;
            return Ok(persons);
        }

        // Get api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(Guid id)
        {
            var person = _context.Find(typeof(Person), id);
            return Ok(person);
        }

        // Post api/Values
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            return Created("",person.Id);
        }

        //Put api/Values/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id ,[FromBody]Person person)
        {
            var Personnal = _context.Persons.Where(c => c.Id == id).FirstOrDefault();


            Personnal.Id = id;
            Personnal.Name = person.Name;
            Personnal.Gender = person.Gender;
            Personnal.Birthday = person.Birthday;
          
             _context.Update(Personnal);
            _context.SaveChanges();

            return Ok(Personnal);
        }

        //Delete api/Values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var personnal = _context.Find(typeof(Person), id);
            _context.Remove(personnal);
            _context.SaveChanges();

            return Ok(personnal);
        }
        
    }
}