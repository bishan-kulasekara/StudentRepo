using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRepo.Server.Data;
using StudentRepo.Server.Models;

namespace StudentRepo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSummaryDTO>>> GetStudents(
                [FromQuery] string? searchQuery = null,
                [FromQuery] string? sortBy = "FirstName",
                [FromQuery] string? sortDirection = "asc"
            )
        {
            var query = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(s => s.FirstName.Contains(searchQuery) ||
                                         s.LastName.Contains(searchQuery) ||
                                         s.Mobile.Contains(searchQuery) ||
                                         s.Email.Contains(searchQuery) ||
                                         s.NIC.Contains(searchQuery));
            }
            query = sortDirection.ToLower() switch
            {
                "desc" => sortBy.ToLower() switch
                {
                    "lastname" => query.OrderByDescending(s => s.LastName),
                    "mobile" => query.OrderByDescending(s => s.Mobile),
                    "email" => query.OrderByDescending(s => s.Email),
                    "nic" => query.OrderByDescending(s => s.NIC),
                    _ => query.OrderByDescending(s => s.FirstName)
                },
                _ => sortBy.ToLower() switch
                {
                    "lastname" => query.OrderBy(s => s.LastName),
                    "mobile" => query.OrderBy(s => s.Mobile),
                    "email" => query.OrderBy(s => s.Email),
                    "nic" => query.OrderBy(s => s.NIC),
                    _ => query.OrderBy(s => s.FirstName)
                },
            };

            var studentSummaries = await query
                .Select(s => new StudentSummaryDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Mobile = s.Mobile,
                    Email = s.Email,
                    NIC = s.NIC
                })
                .ToListAsync();

            return Ok(studentSummaries);

        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
