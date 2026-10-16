using System.Data.SqlClient;

namespace api_both.database
{
    public class get_info
    {
        public string get_user_info(string name, string surname)
        {
            string message = string.Empty;
            string connection_string = @"Data source=(localdb)\api_both;database=api_web;";

            try
            {
                using (SqlConnection connect = new SqlConnection(connection_string))
                {
                    int count_user = 0;
                    connect.Open();

                    string query = "SELECT * FROM users WHERE name=@name AND surname=@surname;";
                    SqlCommand run_query = new SqlCommand(query, connect);
                    run_query.Parameters.AddWithValue("@name", name);
                    run_query.Parameters.AddWithValue("@surname", surname);

                    SqlDataReader found_data = run_query.ExecuteReader();

                    while (found_data.Read())
                    {
                        count_user = 1;
                        message = "ID: " + found_data["ID"].ToString() + "\n";
                        message += "Name: " + found_data["Name"].ToString() + "\n";
                        message += "Surname: " + found_data["Surname"].ToString() + "\n";
                        message += "Age: " + found_data["age"].ToString();
                    }

                    if (count_user == 0)
                        message = "incorrect name or surname";
                }
            }
            catch (Exception error)
            {
                message = error.Message;
            }

            return message;
        }
    }
}
/*using Microsoft.Extensions.FileProviders;
using System.Data.SqlClient;

namespace api_both.database
{
    public class get_info
    {
        // Added 'string' as the return type for the method
        public string get_user_info(string name, string surname)
        {
            // Temp variable to hold connection_string and message
            string message = string.Empty;
            string connection_string = @"Data source=(localdb)\api_both;database=api_both";

            // Try and catch all the error if fails to connect
            try
            {
                // Using the using method to prevent memory leaks
                using (SqlConnection connect = new SqlConnection(connection_string))
                {
                    // Temp variable to count based on found results
                    int count_user = 0;

                    // Open the connection
                    connect.Open();

                    // Query to search the user
                    string query = @"select * from users where name='" + name + "' and surname='" + surname + "';";

                    // Run the query using SqlCommand
                    SqlCommand run_query = new SqlCommand(query, connect);

                    // Read or get what the query returns
                    SqlDataReader found_data = run_query.ExecuteReader();

                    // Check if empty or not
                    if (found_data != null)
                    {
                        while (found_data.Read())
                        {
                            // Get the data per column
                            count_user = 1;
                            message = "ID: " + found_data["ID"].ToString();
                            message += found_data["Name"].ToString();
                            message += found_data["Surname"].ToString();
                            message += found_data["age"].ToString();
                        }
                    }

                    // Assign the error message variable if the user is not found
                    if (count_user == 0)
                    {
                        message = "incorrect name or surname";
                    }
                }
            }
            catch (Exception error)
            {
                // Assign error message if crash
                message = error.Message;
            }

            // Return result
            return message;
        }
    }
}*/