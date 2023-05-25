using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MyProject.Tests
{
    public class JsonFileData : DataAttribute
    {
        private readonly string _jsonPath;

        public JsonFileData(string jsonPath)
        {
            _jsonPath = jsonPath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) throw new ArgumentNullException(nameof(testMethod));

            var currnetDir = Directory.GetCurrentDirectory();
            var jsonFullPath = Path.GetRelativePath(currnetDir, _jsonPath);

        
            var jsonData = File.ReadAllText(jsonFullPath);
            var allCases = JsonConvert.DeserializeObject<List<object[]>>(jsonData);

            return allCases;
        }

       
    }
    
}
