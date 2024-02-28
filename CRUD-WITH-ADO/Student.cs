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


        public static void RetrieveStudents()
        {
            //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            string cs = "Data Source = HP-ELITEBOOK\\SQLEXPRESS;initial Catalog= ADODB;Integrated Security = true;";


            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    string query = "SELECT * FROM Student";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    Console.WriteLine($"| {"ID",-5} | {"Name",-15} | {"Gender",-8} | {"Age",-5} |");
                    Console.WriteLine("-------------------------------------------");

                    while (dr.Read())
                    {
                        Console.WriteLine($"| {dr["StudentID"],-5} | {dr["Name"],-15} | {dr["Gender"],-8} | {dr["Age"],-5} |");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }



        public static void UpdateStudent(Student student)
        {
            // string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            string cs = "Data Source = HP-ELITEBOOK\\SQLEXPRESS;initial Catalog= ADODB;Integrated Security = true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    string query = "UPDATE Student SET Name = @Name, Gender = @Gender, Age = @Age WHERE StudentID = @StudentID";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@StudentID", student.StudentID);
                    sqlCommand.Parameters.AddWithValue("@Name", student.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", student.Gender);
                    sqlCommand.Parameters.AddWithValue("@Age", student.Age);

                    connection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student record updated successfully.");
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
