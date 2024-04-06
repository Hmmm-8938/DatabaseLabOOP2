using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace DatabaseLabOOP2
{
    public class CourseManager
    {
        public string connectionString;

        public CourseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Creating Course Table
        public void CreateCourseTable()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Deleting the table incase it already exists
                var query = "DROP TABLE courses";
                using (var cmd = new MySqlCommand(query, connection))
                {
                  cmd.ExecuteNonQuery();
                }
                //Creating table
                query = "CREATE TABLE courses" +
                        "(course_id INT," +
                        "course_name VARCHAR(50)," +
                        "course_credits INT)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();

                }
            }
        }

        // Retrieving all courses
        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            // creating database connection
            using (var connection = new MySqlConnection(connectionString)) 
            {
                // Opens Database Connection
                connection.Open();

                // creating query String
                var query = "SELECT * FROM courses";

                // Create a command to execute query
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = Convert.ToInt32(reader["ID"]),
                                CourseName = reader["Name"].ToString(),
                                CourseCredits = Convert.ToInt32(reader["CREDITS"])
                            });
                        }
                    }
                }
            }
            return courses;
        }

        //Add a new course (AKA. Create of CRUD)
        public void AddCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO courses " +
                    "(course_id, course_name, course_credits) VALUES (@CourseId, @CourseName, @CourseCredits)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseID);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseCredits", course.CourseCredits);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Update a course (AKA. Update of CRUD)
        public void UpdateCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE courses SET " +
                    "course_name = @CourseName, course_credits = @CourseCredits WHERE course_id = @CourseId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourseId", course.CourseID);
                    cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseCredits", course.CourseCredits);
                    cmd.ExecuteNonQuery();

                }
            }
        }


        //Deleting a course (AKA. Delete of CRUD)
        public void DeleteCourse(int courseID)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM courses WHERE course_id = @CourseId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseID);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        //Displaying courses (AKA. Read of CRUD)
        public string ReadCourses()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM courses";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    return (cmd.ExecuteNonQuery().ToString());
                }
            }
        }

    }
}
