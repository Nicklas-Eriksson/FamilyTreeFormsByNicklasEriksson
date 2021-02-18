using System.Configuration;

namespace FamilyTree
{
    public static class Utility
    {
        public static string Cnn(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}