using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_both.Database;
using api_both.database;
using api_both.Models;

namespace api_both.Controllers
{//start of namespace
    [Route("api/[controller]")]
    [ApiController]
    public class asking_user_detail : ControllerBase
    {//start of class
        //global object of User model
        User user1;
        // Post method to accept the name, surname, and age of the user
        [HttpPost]
        public string user_details(string name, string surname, int age)
        {//start of method
            //how to assign local variables and model variables
            user1 = new User()
            {
                //assigning model varables to local variables
                //fullname = name;
                fullname = name,
                surname = surname,
                age = age
            };
            // Pass all the info of the user to store the backend
            store_info store_data = new store_info();
            string message = store_data.store_user_info(user1.fullname, user1.surname, user1.age);
            
            // 2. Remember who just registered (session)
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Surname", surname);
            HttpContext.Session.SetInt32("Age", age);

            // Return the actual database/operation message instead of hardcoded text
            return message;
        }//end of method

        // retrieve user info using name and surname
        [HttpGet]
        public string get_user_info(string name, string surname)
        {//strat of method

            // If the caller didn't provide name/surname, try the session
            if (string.IsNullOrEmpty(name))
                name = HttpContext.Session.GetString("Name");

            if (string.IsNullOrEmpty(surname))
                surname = HttpContext.Session.GetString("Surname");

            // Still nothing? Tell them
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                return "No name/surname provided and nothing in session.";
            get_info get_data = new get_info();


            string message = get_data.get_user_info(name, surname);

            // Return the result back to the client
            return message;
        }//end of method

        [HttpGet("{id}")]//add the root to fix the issue you have here
        public string get_by_id(int id)
        {
            //create an instance/object for getUserInfoById
            getUserInfoById user_id = new getUserInfoById();

            //call method to get user by inputting id
            return " ===User Details ==\n" + user_id.get_user_info_by_Id(id);
        }
    }//end of public class
}//end of namespaxce