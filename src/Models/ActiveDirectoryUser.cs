
using System.DirectoryServices;

namespace StockportGovUK.AspNetCore.ActiveDirectory.Models
{
    public class ActiveDirectoryUser
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone {get; set; }

        public string NetcallId{ get; set; }

        
        public string PayrollNumber{ get; set; }

        public string EmployeeId
        { 
            get
            {
                return PayrollNumber;
            }
        }

        public ActiveDirectoryUser()
        {

        }

        public ActiveDirectoryUser(SearchResult searchResult)
        {
             PayrollNumber = searchResult.Properties["employeeId"][0].ToString();
             Email = searchResult.Properties["mail"][0].ToString();
             Phone = searchResult.Properties["telephonenumber"][0].ToString();
             Username = searchResult.Properties["samaccountname"][0].ToString();
             NetcallId = "TESTtest123";
        }
    }
}