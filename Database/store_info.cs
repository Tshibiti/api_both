using System.Data.SqlClient;

namespace api_both.Database
{
    public class store_info
    {
        public string store_user_info(string name, string surname, int age)
        {
            string message = "";
            string connection_string = @"Data source=(localdb)\api_both;database=api_web;";

            try
            {
                using (SqlConnection connect = new SqlConnection(connection_string))
                {
                    connect.Open();

                    // Use named columns + parameters to avoid SQL injection
                    string query = "INSERT INTO users (Name, Surname, age) VALUES (@name, @surname, @age);";
                    SqlCommand run_query = new SqlCommand(query, connect);
                    run_query.Parameters.AddWithValue("@name", name);
                    run_query.Parameters.AddWithValue("@surname", surname);
                    run_query.Parameters.AddWithValue("@age", age);

                    run_query.ExecuteNonQuery();
                    message = "user registered successfully....";
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
/*using System.Data.SqlClient;
using System.Linq.Expressions;


namespace api_both.Database
{//start of namespace
    public class store_info
    {//start of class
     //method to store the users info
     public string store_user_info(string name, string surname, int age)
        {//start of method
           
            //temp message
            string message = "";

            //connection string to connect 
            string connection_string = @"Data source=(localdb)\api_both;database=api_web;";

            //try and catch
            try
            {//start of try

                //then use the using method to prevent
                //memory leaks
                using (SqlConnection connect = new SqlConnection(connection_string)    )
                {//start of using
                    //open the connection
                    connect.Open();

                    //do a query to insert the users info
                    string query = @"insert into users values('"+name+"','"+surname+"', "+age+");";
                    //creating an instance to run the query using sqlcommand
                    SqlCommand run_query = new SqlCommand( query, connect);

                    //run non query
                    run_query.ExecuteNonQuery();

                    //meassage
                    message = "user registered successfully....";
                    //then close the connection
                    connect.Close();

                }//end of using
            }//end of try

            catch(Exception error)
            {//start of catch
                //error message catch
                message = error.Message;
            }//end of catch

            //return the message
            return message;
        }//end of method

    }//end of class
}//end of namespace
*/