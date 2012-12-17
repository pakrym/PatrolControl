using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PatrolControl.Service.Model
{
    public class ModelInstaller
    {
        public bool Install(string @namespace = "Install.Sql")
        {
            var dc = new DatabaseContext();
            dc.Database.CreateIfNotExists();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames()
                                        .Where(r => r.StartsWith(@namespace)).OrderBy(r => r);

            foreach (var stream in resourceNames.Select(assembly.GetManifestResourceStream).Where(stream => stream != null))
            {
                using (var reader = new StreamReader(stream))
                {
                    var resource = reader.ReadToEnd();
                    if (dc.Database.ExecuteSqlCommand(resource) <= 0)
                    {
                        throw new InvalidOperationException("Failed to execute request: '" + resource + "'");
                    }
                }
            }
            return true;
        }
    }
}