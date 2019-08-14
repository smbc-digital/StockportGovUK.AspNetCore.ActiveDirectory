using System.DirectoryServices;
using StockportGovUK.AspNetCore.ActiveDirectory.Models;

namespace StockportGovUK.AspNetCore.ActiveDirectory
{
    public interface IActiveDirectoryUserFinder
    {
        ActiveDirectoryUser SearchUsersByUsername(string username);
    }
}