using System.Configuration;

namespace FamilyTree
{
    public static class Utility
    {
        /// <summary>
        /// This method gets called when I need a connection to the server database.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Cnn(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}