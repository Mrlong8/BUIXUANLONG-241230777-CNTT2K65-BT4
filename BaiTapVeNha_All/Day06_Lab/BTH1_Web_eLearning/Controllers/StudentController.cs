using BTH1_Web_eLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTH1_Web_eLearning.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            //Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>() {
                new Student()
                {
                    Id = 101,
                    Name = "Hải Nam",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@g.com",
                    Avatar = "/Image/i1.jpg"
                },
                new Student()
                {
                    Id = 102,
                    Name = "Minh Tú",
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@g.com",
                Branch = Branch.BE,
                    Avatar = "/Image/i1.jpg"

                },
                new Student()
                {
                    Id = 103,
                    Name = "Hoàng Phong",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@g.com",
                    Avatar = "/Image/i1.jpg"
                },
                new Student()
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A1-2021",
                    Email = "mai@g.com",
                    Avatar = "/Image/i1.jpg"

                }
             };
        }

        [HttpGet("Add")]
        public IActionResult Create() { 
//lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList(); 
//Để hiển thị select-option trên View cần dùng List<SelectListItem>                                                                     
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create(Student s,IFormFile? avatarFile)
        {
            if (avatarFile != null && avatarFile.Length > 0)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Image");
                string fileName = Guid.NewGuid().ToString() + "_" + avatarFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await avatarFile.CopyToAsync(fileStream);
                }

                s.Avatar = "/Image/" + fileName;
            }
            else
            {
                // Nếu không chọn ảnh thì gán ảnh mặc định
                s.Avatar = "/Image/i1.jpg";
            }

            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            //IFormFile? avatar = model.Avatar;
            return View("Index", listStudents);
        }



        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
    }
}
