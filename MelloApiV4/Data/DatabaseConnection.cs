using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public class DatabaseConnection
    {
     /*   private string sqlConnectionString = @"Data Source = YourDatabaseServerAddress;initial catalog=YourDatabaseName;user id=YourDatabaseLoginId;password=YourDatabaseLoginPassword";

        //This method gets all record from student table    
        private List<Translation> GetAllStudent()
        {
            List<Translation> students = new List<Translation>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Translation>("Select Id, Name, Marks from Student").ToList();
                connection.Close();
            }
            return students;
        }

        //This method inserts a student record in database    
        private int InsertStudent(Translation student)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into Student (Name, Marks) values (@Name, @Marks)", new { Name = student.Name, Marks = student.Marks });
                connection.Close();
                return affectedRows;
            }
        }

        //This method update student record in database    
        private int UpdateStudent(Translation student)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Update Student set Name = @Name, Marks = @Marks Where Id = @Id", new { Id = studentId, Name = txtName.Text, Marks = txtMarks.Text });
                connection.Close();
                return affectedRows;
            }
        }

        //This method deletes a student record from database    
        private int DeleteStudent(Translation student)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from Student Where Id = @Id", new { Id = studentId });
                connection.Close();
                return affectedRows;
            }
        }*/
    }


}
