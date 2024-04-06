using MySqlConnector;

namespace DatabaseLabOOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Connection String
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                UserID = "root",
                Password = "password",
                Database = "coursesdatabase"
            };

            // displaying connection string
            Console.WriteLine(builder.ConnectionString);

            CourseManager courseManager = new CourseManager(builder.ConnectionString);
            
            // Creating courses table
            courseManager.CreateCourseTable();

            // Getting Courses
            List<Course> courses = courseManager.GetAllCourses();

            // Create the Course Objects
            Course course1001 = new Course
            {
                CourseID = 1001,
                CourseName = "Fundamentals of Web Development",
                CourseCredits = 3
            };
            Course course1002 = new Course
            {
                CourseID = 1002,
                CourseName = "Introduction to Full Stack Programming",
                CourseCredits = 3
            };
            Course course1003 = new Course
            {
                CourseID = 1003,
                CourseName = "Databases",
                CourseCredits = 3
            };
            Course course1004 = new Course
            {
                CourseID = 1004,
                CourseName = "Principles of Softwear Design and Analysis",
                CourseCredits = 4
            };
            Course course1005 = new Course
            {
                CourseID = 1005,
                CourseName = "Objected-Oriented Programming",
                CourseCredits = 4
            };
            // C of CRUD (Create)
            Console.WriteLine("Adding the following courses to Database.... Course1001, Course1002, Course1003, Course1004, and Course1005");
            courseManager.AddCourse(course1001);
            courseManager.AddCourse(course1002);
            courseManager.AddCourse(course1003);
            courseManager.AddCourse(course1004);
            courseManager.AddCourse(course1005);
            Console.WriteLine("\n");
            // U of CRUD (Update)
            Console.WriteLine($"Updating the following course.... Course1004" +
                            $"\nPrevious CourseName: Principles of Softwear Design and Analysis" +
                            $"\nNew CourseName: Principles of Software Design and Analysis");
            course1004.CourseName = "Principles of Software Design and Analysis";
            courseManager.UpdateCourse(course1004);
            Console.WriteLine("\n");
            // D of CRUD (Delete)
            Console.WriteLine("Deleting the following course.... Course1005");
            courseManager.DeleteCourse(course1005.CourseID);
            Console.WriteLine("Course1005 Deleted...");
            Console.WriteLine("\n");

            // R of CRUD (Read)
            Console.WriteLine("Courses Display\n");
            Console.WriteLine(course1001.ToString());
            Console.WriteLine(course1002.ToString());
            Console.WriteLine(course1003.ToString());
            Console.WriteLine(course1004.ToString());
        }
    }
}
