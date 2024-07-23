using StudentRepo.Server.Models;

namespace StudentRepo.Server.Helpers
{
    public class FileHelper
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public Student SaveFile(Student student, IFormFile file)
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
