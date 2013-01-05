using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PatrolControl.Service.Model
{
    public class ModelInstaller
    {
        public bool Install(DatabaseContext dc = null, string @namespace = "Install.Sql")
        {
            if (dc == null) dc = new DatabaseContext();
            dc.Database.CreateIfNotExists();

            var assembly = Assembly.GetExecutingAssembly();

            var resourceNames = assembly.GetManifestResourceNames()
                                        .Where(r => r.StartsWith(@namespace)).OrderBy(r => r);
            foreach (var resourceName in resourceNames)
            {
                var rm = new ResourceManager(resourceName.Substring(0,resourceName.LastIndexOf('.')), assembly);
                foreach (var stream in rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true).Cast<DictionaryEntry>().OrderBy(e => e.Key))
                {
                    var resource = stream.Value.ToString();
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