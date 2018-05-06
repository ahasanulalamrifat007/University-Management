using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemMVC.DAL;
using UniversityManagementSystemMVC.Models;

namespace UniversityManagementSystemMVC.BLL
{
    public class CourseAssignToTeacherManager
    {
        CourseAssignToTeacherGetWay assignToTeacherGetWay=new CourseAssignToTeacherGetWay();

        public int AssignCourseToTeacher(CourseAssignToTeacher assign)
        {
            return assignToTeacherGetWay.AssignCourseToTeacher(assign);
        }

        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachers()
        {
            return assignToTeacherGetWay.GetAllCourseassinAssignToTeachers();
        }

        public void UpdateRemainingCredit(double credit, int id)
        {
            assignToTeacherGetWay.UpdateRemainingCredit(credit, id);
        }

        //Status True
        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachersTrue()
        {
            return assignToTeacherGetWay.GetAllCourseassinAssignToTeachersTrue();
        }

        //Status False
        public List<CourseAssignToTeacher> GetAllCourseassinAssignToTeachersFalse()
        {
            return assignToTeacherGetWay.GetAllCourseassinAssignToTeachersFalse();
        }
        //Update
        public int UpdateAssignCourse(CourseAssignToTeacher assign)
        {
            return assignToTeacherGetWay.UpdateAssignCourse(assign);
        }
    }
}