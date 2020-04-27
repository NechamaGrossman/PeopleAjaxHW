using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PeopleAjaxHw.Data
{
    public class PersonDb
    {
        string _connectionString;
        public PersonDb(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        public List<Person> GetPeople()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"select * From Person";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Person> people = new List<Person>();
                while (reader.Read())
                {
                    Person p = new Person
                    {
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"],
                        Id = (int)reader["Id"]

                    };
                    people.Add(p);
                }
                return people;
            }
        }
        
        public void EditPerson(Person p)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"update Person set FirstName= @FirstName, LastName=@LastName, Age=@Age Where Id=@Id";
                command.Parameters.AddWithValue("@FirstName", p.FirstName);
                command.Parameters.AddWithValue("@LastName", p.LastName);
                command.Parameters.AddWithValue("@age", p.Age);
                command.Parameters.AddWithValue("@Id", p.Id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) ;
            }
        }
        public void DeletePerson(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"Delete from Person where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) ;
            }
        }
    }
}
