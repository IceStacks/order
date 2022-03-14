using System;
using Microsoft.Extensions.Configuration;

namespace Extensions
{
    public static class EnvironmentVariableExtensions
    {
        public static string GetConnectionStringFromEnvironment(this IConfiguration configuration, string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                string envServer = Environment.GetEnvironmentVariable("DB_HOST"); 
                string envDatabase = Environment.GetEnvironmentVariable("DB_NAME"); 
                string envUser = Environment.GetEnvironmentVariable("DB_USER"); 
                string envPassword = Environment.GetEnvironmentVariable("DB_PASS"); 
                return "Server="+envServer+";Database="+envDatabase+";Uid="+envUser+";Pwd="+envPassword+";";
            }
            else
            {
                return Environment.GetEnvironmentVariable(name);
            }
        }
    }
}
