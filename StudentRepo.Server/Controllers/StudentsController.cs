using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using StudentRepo.Server.Data;
using StudentRepo.Server.Models;
using Microsoft.AspNetCore.Hosting;

namespace StudentRepo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StudentsController(StudentContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSummaryDTO>>> GetStudents(
                [FromQuery] string? searchQuery = null,
                [FromQuery] string? sortBy = "FirstName",
                [FromQuery] string? sortDirection = "asc",
                [FromQuery] int? pageNumber = 1,
                [FromQuery] int? pageSize = 10
            )
        {
            var query = _context.Students.AsQueryable();
            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 10;

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
            var totalRecords = await query.CountAsync();
            var studentSummaries = await query
                .Skip((currentPageNumber - 1) * currentPageSize)
                .Take(currentPageSize)
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
            var pagedResult = new PagedResult<StudentSummaryDTO>
            {
                Data = studentSummaries,
                TotalRecords = totalRecords,
                PageNumber = currentPageNumber,
                PageSize = currentPageSize
            };

            //return Ok(studentSummaries);
            var totalPages = (int)Math.Ceiling(totalRecords / (double)currentPageSize);
            if (currentPageNumber> totalPages)
            {
                return BadRequest(new { message="Invalid page number"});
            }

            return Ok(pagedResult);
            

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
        public async Task<IActionResult> PutStudent(int id, [FromForm] Student student, [FromForm] IFormFile? file)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(student.FirstName))
            {
                existingStudent.FirstName = student.FirstName;
            }
            if (!string.IsNullOrEmpty(student.LastName))
            {
                existingStudent.LastName = student.LastName;
            }
            if (!string.IsNullOrEmpty(student.Mobile))
            {
                existingStudent.Mobile = student.Mobile;
            }
            if (!string.IsNullOrEmpty(student.Email))
            {
                existingStudent.Email = student.Email;
            }
            if (!string.IsNullOrEmpty(student.NIC))
            {
                existingStudent.NIC = student.NIC;
            }
            if (!string.IsNullOrEmpty(student.Address))
            {
                existingStudent.Address = student.Address;
            }
            if (student.DateOfBirth != default)
            {
                existingStudent.DateOfBirth = student.DateOfBirth;
            }

            if (file != null && file.Length > 0)
            {
                if (!string.IsNullOrEmpty(existingStudent.ProfileImage))
                {
                    DeleteFile(existingStudent);
                }
                existingStudent = SaveFile(existingStudent, file);
            }

            _context.Entry(existingStudent).State = EntityState.Modified;

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
        public async Task<ActionResult<Student>> PostStudent([FromForm] Student student, [FromForm] IFormFile? file)
        {
            

            if (file != null && file.Length > 0)
            {
                student=SaveFile(student, file);
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }




        [HttpPost("{id}/upload")]
        public async Task<IActionResult> UploadProfileImage(int id, IFormFile file)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            if (file.Length > 0)
            {
                if (string.IsNullOrEmpty(_hostingEnvironment.WebRootPath))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Web root path is not configured.");
                }

                var uniqueFileName = $"{id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueFileName);

                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads")); // Ensure the directory exists

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                student.ProfileImage = $"/uploads/{uniqueFileName}";
                await _context.SaveChangesAsync();
            }

            return Ok(student);
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
            DeleteFile(student);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public  Student SaveFile(Student student, IFormFile file)
        {
            if (string.IsNullOrEmpty(_hostingEnvironment.WebRootPath))
            {
                throw new InvalidOperationException("Web root path is not configured.");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Web root path is not configured.");
            }

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueFileName);

            Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads")); // Ensure the directory exists

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                 file.CopyToAsync(stream);
            }
            student.ProfileImage = $"/uploads/{uniqueFileName}";
            return student;
        }
        public void DeleteFile(Student student)
        {
            if (!string.IsNullOrEmpty(student.ProfileImage))
            {
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", Path.GetFileName(student.ProfileImage));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }
    }


}
