using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityManagementSystemMVC.BLL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult ViewResult()
        {
            StudentManager aStudentManager=new StudentManager();
            ViewBag.students=aStudentManager.GetAllStudents();
            return View();
        }

        [HttpPost]

        public ActionResult ViewResult(StudentViewResult aStudentViewResult)
        {
            StudentManager aStudentManager = new StudentManager();
            ViewBag.students = aStudentManager.GetAllStudents();


            //PDF
            var document = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
            PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            var name = new Paragraph("Name  :" + aStudentViewResult.Name + "\n\nRegistrationNo   :" + aStudentViewResult.RegistrationNo + "\n\nDepartment         :" + aStudentViewResult.DepartmentName + "\n\nEmail           :" + aStudentViewResult.Email);

            var newli = new Paragraph("\n");

            name.Alignment = Element.ALIGN_CENTER;
            //regNo.Alignment = Element.ALIGN_CENTER;
            //dep.Alignment = Element.ALIGN_CENTER;
            //emal.Alignment = Element.ALIGN_CENTER;

            document.Add(name);
            document.Add(newli);
            //document.Add(regNo);
            document.Add(newli);
            //document.Add(dep);
            document.Add(newli);
            //document.Add(emal);

            //create pdf table
            var table = new PdfPTable(3) { TotalWidth = 216f };
            var widths = new float[] { 4f, 5f, 2f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 30f;
            table.SpacingAfter = 40f;

            var ph = new Phrase("Result Sheet");
            var nphs = new Phrase("\n");

            var first = new Phrase("Course Code");
            var second = new Phrase("Course Name");
            var third = new Phrase("Grade");

            var cell = new PdfPCell(ph);
            var ncelll = new PdfPCell(nphs);
            var fcelll = new PdfPCell(first);
            var scelll = new PdfPCell(second);
            var tcelll = new PdfPCell(third);


            cell.Colspan = 3;
            cell.Border = 0;
            cell.HorizontalAlignment = 1;

            ncelll.Colspan = 3;
            ncelll.Border = 0;
            ncelll.HorizontalAlignment = 1;

            fcelll.Colspan = 0;
            fcelll.Border = Rectangle.BOX;
            fcelll.HorizontalAlignment = 1;

            scelll.Colspan = 0;
            scelll.Border = Rectangle.BOX;
            scelll.HorizontalAlignment = 1;

            tcelll.Colspan = 0;
            tcelll.Border = Rectangle.BOX;
            tcelll.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell(ncelll);
            table.AddCell(fcelll);
            table.AddCell(scelll);
            table.AddCell(tcelll);

            string connect = "Server=OSANSHAON-PC;Database=University System DB;Trusted_Connection=True;";
            var conn = new SqlConnection(connect);
            string query = "SELECT CourseCode, CourseName, Grade FROM viewresult WHERE RegistrationNO='" + aStudentViewResult.RegistrationNo + "' AND Status='1'";
            var cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                table.AddCell(rdr[0].ToString());
                table.AddCell(rdr[1].ToString());
                table.AddCell(rdr[2].ToString());
            }
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            document.Add(table);
            document.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;  filename = viewresult.pdf");
            Response.End();

            return View();
        }

        

        public JsonResult GetStudentByRegNo(string RegNo)
        {
            StudentDepartmentManager aStudentDepartmentManager=new StudentDepartmentManager();
            var students = aStudentDepartmentManager.GetStudentInfoWithDepartmentName();
            var student = students.FirstOrDefault(a => a.RegistrationNo == RegNo);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTableValue(string RegNo)
        {
            StudentViewResultManager aManager=new StudentViewResultManager();
            var students = aManager.GetViewResult(RegNo);
            var student = students.Where(a => a.RegistrationNo == RegNo).ToList();
            return Json(student, JsonRequestBehavior.AllowGet);
        }
    }
}