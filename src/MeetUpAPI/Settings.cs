using Microsoft.Extensions.Configuration;
using System;

namespace MeetUpAPI
{
    public static class Settings
    {
        public static string GetConnectionString(string name) => Environment.ExpandEnvironmentVariables(Startup.Configuration.GetConnectionString(name));
        public static string Get(string name) => Environment.ExpandEnvironmentVariables(Startup.Configuration[name]);
        public static string TrimUrl(string url) => url.Trim(' ', '/');
        public static string JoinPath(this string src, string path) => $"{TrimUrl(src)}/{TrimUrl(path)}";
    }
}


