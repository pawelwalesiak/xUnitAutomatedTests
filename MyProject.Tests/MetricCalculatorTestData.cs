using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MyProject.Tests
{
    internal class MetricCalculatorTestData : IEnumerable<object[]>
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "MetricBmiCalculatorData.json");

        public IEnumerator<object[]> GetEnumerator()
        {
            var jsonData = File.ReadAllText(_filePath);
            var allCases = JsonConvert.DeserializeObject<List<object[]>>(jsonData);

            return allCases.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
