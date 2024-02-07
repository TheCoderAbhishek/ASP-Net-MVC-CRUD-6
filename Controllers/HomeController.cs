using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace CRUD_Basic.Controllers
{
    public class HomeController : Controller
    {
        MVCDBContext _MVCDBContext = new MVCDBContext();
        public ActionResult Index()
        {
            var listOfStudents = _MVCDBContext.StudentDatas.ToList();
            return View(listOfStudents);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentData studentData)
        {
            _MVCDBContext.StudentDatas.Add(studentData);
            _MVCDBContext.SaveChanges();
            ViewBag.Message = "Data successfully inserted.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tableData = _MVCDBContext.StudentDatas.Where(x => x.StudentId == id).FirstOrDefault();
            return View(tableData);
        }

        [HttpPost]
        public ActionResult Edit(StudentData studentData)
        {
            var tableData = _MVCDBContext.StudentDatas.Where(x => x.StudentId == studentData.StudentId).FirstOrDefault();
            if (tableData != null)
            {
                tableData.StudentName = studentData.StudentName;
                tableData.StudentFees = studentData.StudentFees;
                tableData.StudentHomeCity = studentData.StudentHomeCity;
                _MVCDBContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var tableData = _MVCDBContext.StudentDatas.Where(x => x.StudentId == id).FirstOrDefault();
            return View(tableData);
        }

        public ActionResult Delete(int id)
        {
            var tableData = _MVCDBContext.StudentDatas.Where(x => x.StudentId == id).FirstOrDefault(x => x.StudentId == id);
            _MVCDBContext.StudentDatas.Remove(tableData);
            _MVCDBContext.SaveChanges();
            ViewBag.Message = "Record Delete Successfully.";
            return RedirectToAction("Index");
        }
    }
}