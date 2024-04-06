using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLabOOP2
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseCredits { get; set; }

        public Course()
        {
            
        }

        public override string ToString()
        {
            return ($"CourseID: {CourseID}" +
                  $"\tCourseName: {CourseName}" +
                  $"\tCourseCredits: {CourseCredits}");
        }
    }
}
