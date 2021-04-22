using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginApp.Services.Data
{
    public class SecurityDAO
    {
        // connect to the database
        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Test;Integrated Security=True;Connect" +
            " Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            //    if (user.Username == "Admin" && user.Password == "Admin123")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //Alternative way
            //return (user.Username == "Admin" && user.Password == "Admin123");
            // start by assuming that nothing is found in this query
            bool success = false;
            // write sql  expression
            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";

            // create and open the connection to the database inside using a block .

            //this ensures that all resources are closed properly when the query is done 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and parameter object
                SqlCommand command = new SqlCommand(queryString , connection);
                // associate @username with user.username 
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                // open the database andrun the command
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return success;

        }
    }
}