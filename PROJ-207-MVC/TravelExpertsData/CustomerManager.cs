using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class CustomerManager
    {
        // get a list of customers 
        public static List<Customer> GetCustomers(TravelExpertsContext db) // customer retrieved from the database
        {
            List<Customer> customers = db.Customers.ToList(); //customer db to list 
            return customers;
        }
        //authenticate if the username and password exist
        public static Customer Authenticate(TravelExpertsContext db, string username, string password)
        {
            List<Customer> customers = GetCustomers(db);// list of customer object calls for getcustomers method with db
            var customer = customers.SingleOrDefault(cus => cus.CustUsername == username && cus.CustPassword == password); //will be an object if it finds a match
            return customer; //this will either be null or an object
        }
    }
}
