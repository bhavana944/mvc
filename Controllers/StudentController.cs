using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentDetails_MVC_.Models;
using System.Text;

namespace StudentDetails_MVC_.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        public ActionResult GetStudentDetails()
        {
            //ModelState.Clear();
            return View(dataAccessLayer.GetAllStudentDetails());
        }
        public ActionResult AddStudentDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentDetails(StudentDetails studentDetails, string drawing, string cooking, string swimming, string playing ,string[] subjects) 
        {
            if (ModelState.IsValid)
            {
                if (drawing == "true")
                {
                    studentDetails.Hobbies = "drawing";
                }
                if (cooking == "true")
                {
                    studentDetails.Hobbies = "cooking" + ","+studentDetails.Hobbies;
                }
                if (swimming == "true")
                {
                    studentDetails.Hobbies = "swimming" + "," + studentDetails.Hobbies;
                }
                if (playing == "true")
                {
                    studentDetails.Hobbies = "playing" + "," + studentDetails.Hobbies;
                }
                studentDetails.Subjects = string.Join(",", subjects);
                dataAccessLayer.InsertAndUpdateStudentDetails(studentDetails);
                return RedirectToAction("GetStudentDetails");
            }
            return View();
        }
        
        public ActionResult DeleteStudentDetails(int id)
        {
            if(ModelState.IsValid)
            {
                dataAccessLayer.DeleteStudentDetails(id);
                return RedirectToAction("GetStudentDetails");
            }
            return View();
        }
        public ActionResult EditStudentDetails(int id)
        {
            string drawing = "false", cooking = "false", swimming = "false", playing = "false";
            var student = dataAccessLayer.GetAllStudentDetails().Find(e => e.Id == id) ;
            var hobbies = student.Hobbies.Split(',');
            var subjects = student.Subjects.Split(',');
            StringBuilder subject = new StringBuilder();
            for (int i = 0; i < subjects.Length; i++)
            {
                subject.Append(subjects[i]);
            }
            ViewData["Subject"] = subjects;


            for (int i = 0; i < hobbies.Length; i++)
            {
                //drawing = hobbies[i] == "drawing" ? "true" : "false";
                //cooking = hobbies[i] == "cooking" ? "true" : "false";
                //swimming = hobbies[i] == "swimming" ? "true" : "false";
                //playing = hobbies[i] == "playing" ? "true" : "false";
                if (hobbies[i] == "drawing")
                    drawing = "true";
                if (hobbies[i] == "cooking")
                    cooking = "true";
                if (hobbies[i] == "swimming")
                    swimming = "true";
                if (hobbies[i] == "playing")
                    playing = "true";
            }
            ViewBag.drawing = drawing;
            ViewBag.cooking = cooking;
            ViewBag.swimming = swimming;
            ViewBag.playing = playing;
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudentDetails(StudentDetails studentDetails ,string drawing, string cooking, string swimming, string playing)
        {
            if (ModelState.IsValid)
            {
                if (drawing == "true")
                {
                    studentDetails.Hobbies = "drawing";
                }
                if (cooking == "true")
                {
                    studentDetails.Hobbies = "cooking" + "," + studentDetails.Hobbies;
                }
                if (swimming == "true")
                {
                    studentDetails.Hobbies = "swimming" + "," + studentDetails.Hobbies;
                }
                if (playing == "true")
                {
                    studentDetails.Hobbies = "playing" + "," + studentDetails.Hobbies;
                }
                //  studentDetails.Subjects = string.Join(",", Subjects);
                dataAccessLayer.InsertAndUpdateStudentDetails(studentDetails);
                return RedirectToAction("GetStudentDetails");
            }

            return View();
        }
      
        
    }
}