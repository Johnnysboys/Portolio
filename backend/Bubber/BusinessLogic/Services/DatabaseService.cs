using System.IO;
using System;
using System.Collections.Generic;
namespace Bubber.BusinessLogic.Services
{
    public class DatabaseService
    {

        private Dictionary<string, string> database;
        private string DatabaseFolder = "./data/";
        private string DatabaseExtension = "db";
        private string DatabaseName;
        private string DatabasePath;
        public DatabaseService(string DatabaseName)
        {
            this.DatabaseName = DatabaseName;
            string DatabaseFile = string.Concat(this.DatabaseName, '.', this.DatabaseExtension);
            this.DatabasePath = string.Concat(this.DatabaseFolder, "/", DatabaseFile);
            this.InitializeDatabase(DatabasePath);
        }
        private void InitializeDatabase(string Path)
        {
            if (!Directory.Exists(DatabaseFolder))
                Directory.CreateDirectory(DatabaseFolder);
            if (!File.Exists(DatabasePath))
                File.Create(DatabasePath);
            Console.WriteLine(this.DatabaseName + " Database initialized");
        }

        private void WriteToDatabase(string Path, string data)
        {

        }

        private void LoadDatabase(string Path)
        {
            try
            {
                foreach (string line in File.ReadLines(this.DatabasePath))
                {
                    Console.WriteLine(line);
                };
            }
            catch (System.Exception)
            {

                throw;
            }
        }


    }
}