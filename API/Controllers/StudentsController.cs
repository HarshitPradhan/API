using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppContext _context;

        public StudentsController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Getstudents()
        {
            return Ok(await _context.students.ToListAsync());
        }

        // GET: api/Students/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Student>> GetStudent(int Id)
        {
            var student = await _context.students.FindAsync(Id);

            if (student == null)
            {
                return BadRequest();
            }

            return Ok(student);
        }

        
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> Addstudent(Student student)
        {
            _context.students.Add(student);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(Student student)
        {

            if (ModelState.IsValid)
            {
                _context.students.Update(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            return BadRequest();
        }


        // DELETE: api/Students/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await _context.students.FindAsync(Id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int Id)
        {
            return _context.students.Any(e => e.Id == Id);
        }
    }
}
