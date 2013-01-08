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
        public bool Install(DatabaseContext dc, string @namespace)
        {
            dc.Database.CreateIfNotExists();

            var assembly = Assembly.GetExecutingAssembly();

            var resourceNames = assembly.GetManifestResourceNames()
                                        .Where(r => r.StartsWith(@namespace) && r.ToLower().EndsWith(".sql"))
                                        .OrderBy(r => r).ToArray();

            foreach (var resourceName in resourceNames)
            {
                var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) continue;
                
                using (var reader = new StreamReader(stream))
                {
                    var result = dc.Database.ExecuteSqlCommand(reader.ReadToEnd());
                }
            }
            return true;
        }
    }
}