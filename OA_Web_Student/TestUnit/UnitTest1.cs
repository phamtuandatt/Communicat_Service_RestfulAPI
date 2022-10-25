using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using NuGet.DependencyResolver;
using OA_Data;
using OA_Repo;
using OA_Service;
using System.Configuration;

namespace TestUnit
{
    public class Tests
    {
        ApplicationDbContext _context;
        IRepo<Student> _student;
        //.UseInMemoryDatabase("Web_StudentAPI")

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Server=PC-DATPHAM\\PTUANDAT;Initial Catalog=Web_StudentAPI;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True")
                .Options;

            _context = new ApplicationDbContext(contextOptions);

            _student = new Repo<Student>(_context);
        }

        [Test]
        public void Test2()
        {

            var mockRepo = new Mock<IRepo<Student>>();
            var lsr = mockRepo.Setup(s => s.Get(5));

            Assert.IsNotNull(lsr);

        }

        [Test]
        public void Test1()
        {
            //_student = new Repo<Student>(_context);
            Student student = new Student
            {
                Id = 20,
                Name = "David",
                DayOfBirth = DateTime.Now,
                Phone = "0564987123",
                Email = "david@gmail.com",
                Address = "Phu My, BRVT",
                MaLop = 1
            };

            //var obj = _student.Insert(student);

            var mockRepo = new Mock<IRepo<Student>>();
            var rs = mockRepo.Setup(s => s.Insert(student));

            Assert.IsNotNull(rs);
        }
    }
}