using System.Data.SqlClient;

namespace CRUD_UsingADO
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Student(string name, string gender, int age)
        {

            Name = name;
            Gender = gender;
            Age = age;
        }

        public Student()
        {

        }

        public static void InsertStudent(Student student)
        {
            string cs = "Data Source = HP-ELITEBOOK\\SQLEXPRESS;initial Catalog= ADODB;Integrated Security = true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    string query = "INSERT INTO Student ( Name, Gender, Age) VALUES (@Name, @Gender, @Age)";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@Name", student.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", student.Gender);
                    sqlCommand.Parameters.AddWithValue("@Age", student.Age);

                    connection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student record inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No rows affected.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
