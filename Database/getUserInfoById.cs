using System.Data.SqlClient;
using api_both.Models;

namespace api_both.Database
{
    public class getUserInfoById
    {
        public string connection_string = @"Data source=(localdb)\api_both;database=api_web;";
        public string message = string.Empty;

        public User get_user_info_by_Id(int id)
        {
            User user = null;
            try
            {
                using (SqlConnection connect = new SqlConnection(connection_string))
                {
                    connect.Open();

                    string query = "SELECT * FROM users WHERE id=@id;";
                    SqlCommand run_query = new SqlCommand(query, connect);
                    run_query.Parameters.AddWithValue("@id", id);

                    SqlDataReader found_data = run_query.ExecuteReader();

                    if (found_data.Read())
                    {
                        user = new User();
                        user.Id = Convert.ToInt32(found_data["ID"]);
                        user.fullname = found_data["Name"].ToString();
                        user.surname = found_data["Surname"].ToString();
                        user.age = Convert.ToInt32(found_data["age"]);
                    }
                }
            }
            catch (Exception error)
            {
                message = error.Message;
            }

            return user;
        }
    }
}

/*using System.Xml.Linq;
using System.Data.SqlClient;
using api_both.Models;

namespace api_both.Database
{
    public class getUserInfoById
    {
        //cretating a connection string
        public string connection_string = @"Data source = (localdb)\api_both;database=api_web;";
       //create a temp variable called message to store empty string
       public string message = string.Empty;
        //lets create a method to get the user info by id calld get_user_info_by_id
        /// <summary>
        /// /////public string get_user_info_by_Id(int id) 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //// Method that returns a UserModel instead of string
        public User get_user_info_by_Id(int id)
        { //start of method
            //create a try and catch
            User user = null;//// Initialize user variable to null
            try
            {//start of try
             // Using the using method to prevent memory leaks
                using (SqlConnection connect = new SqlConnection(connection_string))
                {
                    // Temp variable to count based on found results
                    int count_user = 0;

                    // Open the connection
                    connect.Open();

                    // Query to search the user
                    string query = @"select * from users where id='" + id + "';";

                    // Run the query using SqlCommand
                    SqlCommand run_query = new SqlCommand(query, connect);

                    // Read or get what the query returns
                    SqlDataReader found_data = run_query.ExecuteReader();
                    /*

                    // Check if empty or not
                    if (found_data != null)
                    {
                        while (found_data.Read())
                        {
                            // Get the data per column

                            count_user = 1;
                            message = "ID: " + found_data["ID"].ToString();
                            message += "\nName: " + found_data["Name"].ToString();
                            message += "\nSurname: " + found_data["Surname"].ToString();
                            message += "\nAge: " + found_data["age"].ToString();
                        }
                    }

                    // Assign the error message variable if the user is not found
                    if (count_user == 0)
                    {
                        message = "incorrect id, user not found ";
                    }*//*
                    if (found_data.Read())
                    {
                        // Create and fill the UserModel object
                        user = new User();
                        user.Id = Convert.ToInt32(found_data["ID"]);
                        user.fullname = found_data["Name"].ToString();
                        user.surname = found_data["Surname"].ToString();
                        user.age = Convert.ToInt32(found_data["age"]);
                    }
                }

            }//end of try
            catch(Exception error)
            {
                message = error.Message;
            }//end of catch

            //return message;
            return user;//return the user object
        }//end of method

    }//end of class
}
*/