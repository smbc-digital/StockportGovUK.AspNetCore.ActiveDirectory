using System.DirectoryServices;
using StockportGovUK.AspNetCore.ActiveDirectory.Models;

namespace StockportGovUK.AspNetCore.ActiveDirectory
{
    public class ActiveDirectoryUserFinder : IActiveDirectoryUserFinder
    {
        private string NamingContext { get; set; }

        private DirectorySearcher DirectorySearcher { get; set; }

        public ActiveDirectoryUserFinder(string namingContext)
        {
            NamingContext = namingContext;
            DirectorySearcher = new DirectorySearcher("LDAP://" + NamingContext);
        }

        public ActiveDirectoryUserFinder()
        {
            DirectoryEntry rootDirectoryEntry = new DirectoryEntry("LDAP://RootDSE");
            NamingContext = (string)rootDirectoryEntry.Properties["defaultNamingContext"].Value; 
            DirectorySearcher = new DirectorySearcher("LDAP://" + NamingContext);
        }

        public ActiveDirectoryUser SearchUsersByUsername(string username)
        {
                DirectorySearcher.Filter = $"(&(objectClass=user)(sAMAccountname={username}))";
                var searchResult = DirectorySearcher.FindOne();
                var user = new ActiveDirectoryUser(searchResult);
                return user; 
        }
    }
}