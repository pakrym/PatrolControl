using System;
using System.Collections;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PatrolControl.Service.Model
{
    public class ModelInstaller<T> : DropCreateDatabaseAlways<T> where T : DbContext
    {
        const string Namespace = "PatrolControl.Service.Model.Sql";

        protected override void Seed(T context)
        {
            base.Seed(context);

            var assembly = Assembly.GetExecutingAssembly();

            var resourceNames = assembly.GetManifestResourceNames()
                                        .Where(r => r.StartsWith(Namespace) && r.ToLower().EndsWith(".sql"))
                                        .OrderBy(r => r).ToArray();

            foreach (var resourceName in resourceNames)
            {
                var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) continue;

                using (var reader = new StreamReader(stream))
                {
                    var result = context.Database.ExecuteSqlCommand(reader.ReadToEnd());
                }
            }
        }
    }
}