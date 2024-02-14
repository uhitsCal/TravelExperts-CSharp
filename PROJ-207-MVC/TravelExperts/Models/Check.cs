using TravelExpertsData;

namespace TravelExperts.Models
{
    public class check
    {
       //check if username exist in the database
        public static string UserNameExists(TravelExpertsContext db, string username)
        {
            string msg = string.Empty; //empty string
            if (!string.IsNullOrEmpty(username)) //if if username passing through is not null
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustUsername.ToLower() == username.ToLower()); //check the first match and compare to db
                if (customer != null) //if customer is not null (name was found as match)
                    msg = $"The Username {username} is already in use."; //set message as validation
            }
            return msg; //return message
        }

    }
}
