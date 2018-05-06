using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult RegisterStudent()
        {
            Student aStudent = new Student();
            aStudent.Date = DateTime.Today;
            DepartmentManager aDepartmentManager = new DepartmentManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            return View(aStudent);
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            Department aDepartment = new Department();
            aStudent.Code = aDepartment.Code;
            DepartmentManager aDepartmentManager = new DepartmentManager();
            ViewBag.departments = aDepartmentManager.GetAllDepartmentInfo();
            StudentManager aStudentManager = new StudentManager();
            int totalNo = aStudentManager.NoOfRegistraion();
            var code = aStudentManager.GetDepartmentCodeById(aStudent.DepartmentId);
            var Year = aStudent.Date.Year;
            int no = 1;
            string RegNo = "";
            //= (code + "-" + Year + "-") + (no.ToString().PadLeft(3, '0'));
            string codeyear = (code + "-" + Year);
            int codeyearcount = codeyear.Length;
            int abc = 1;
            if (totalNo > 0)
            {
                abc = aStudentManager.NoOfCodeAndYear(codeyearcount, codeyear);
                if (abc > 0)
                {
                    abc += 1;
                    RegNo = (code + "-" + Year + "-") + abc.ToString().PadLeft(3, '0');
                }
                else
                {

                    RegNo = (code + "-" + Year + "-") + no.ToString().PadLeft(3, '0');
                }
            }
            else
            {

                RegNo = (code + "-" + Year + "-") + no.ToString().PadLeft(3, '0');
            }

            aStudent.RegistrarionNo = RegNo;
            var alStudents = aStudentManager.GetAllStudents();
            if (aStudent.Name == null || aStudent.Email == null || aStudent.ContactNo == null ||
                aStudent.Address == null || aStudent.DepartmentId == 0)
            {
                ViewBag.message = "Input Values";
            }
            else
            {
                var studentlist = aStudentManager.GetAllStudents();
                var studentemail = studentlist.FirstOrDefault(s => s.Email == aStudent.Email);
                if (studentemail != null)
                {
                    ViewBag.message = "Email Already Exist";
                }
                else
                {
                    if (aStudentManager.SaveStudent(aStudent) > 0)
                    {
                        ViewBag.message = "Student Info Saved Successfully";
                    }
                    else
                    {
                        ViewBag.message = "Failed insertion";
                    }
                }
            }

            return View();
        }

       public JsonResult GetStudentInfoByRegNo(string RegNo)
        {
            StudentDepartmentManager aStudentManager = new StudentDepartmentManager();
            var students = aStudentManager.GetStudentInfoWithDepartmentName();
            var student = students.FirstOrDefault(a => a.RegistrationNo == RegNo);
            return Json(student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEnrollCourseByRegNo(string RegNo)
        {
            SCDManager aScdManager=new SCDManager();
            var students = aScdManager.GetStudentInfoWithDepartmentNameAndCourse();
            var student = students.Where(a => a.RegistrationNo == RegNo).ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnrollCourseByRegNoTrue(string RegNo)
        {
            SCDManager aScdManager = new SCDManager();
            var students = aScdManager.GetStudentInfoWithDepartmentNameAndCourseTrue();
            var student = students.Where(a => a.RegistrationNo == RegNo).ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }




        //Save Student Result

        public ActionResult SaveResult()
        {
            StudentManager aStudentManager = new StudentManager();
            GradeManager aGradeManager=new GradeManager();
            ViewBag.students = aStudentManager.GetAllStudents();
            ViewBag.gredes = aGradeManager.GetAllGrades();
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(StudentResult aStudentResult)
        {
            StudentManager aStudentManager = new StudentManager();
            GradeManager aGradeManager = new GradeManager();
            StudentResultManager aStudentResultManager=new StudentResultManager();
            ViewBag.students = aStudentManager.GetAllStudents();
            ViewBag.gredes = aGradeManager.GetAllGrades();
            var studentlist = aStudentResultManager.GetAllStudentResultsByRegNo(aStudentResult.RegistrationNo);
            var studentcourse = studentlist.FirstOrDefault(s => s.CourseId == aStudentResult.CourseId);
            if (aStudentResult.CourseId == 0)
            {
                ViewBag.message = "Select Course";
            }
            else
            {
                if (studentcourse != null)
                {
                    ViewBag.message = "This Course Grade Already Exist";
                }
                else
                {
                    if (aStudentResultManager.SaveStudentResult(aStudentResult) > 0)
                    {
                        ViewBag.message = "Result Saved Successfully";
                    }
                    else
                    {
                        ViewBag.message = "Save Failed";
                    }
                }
            }

            return View();
        }
    }
}