using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class MetricCalculatorBmiTests
    {
        public static IEnumerable<object[]> GetSampleData()
        {
            yield return new object[] { 100, 170, 34.6 };
            yield return new object[] { 57, 170, 19.72 };
            yield return new object[] { 70, 170, 24.22 };
           // yield return new object[] { 70, 170 }; -> nie dostanę błedu kompilaji sam muszę sprawdzać ile parametrów podaje


        }

        [Theory]
        //  [InlineData(100, 170, 34.6)]
        //  [InlineData(57, 170, 19.72)]
        //  [InlineData(70, 170, 24.22)]
        [MemberData(nameof (GetSampleData))]
        public void CalculateBmi_ForgivenWightAndHeidht_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        { 
            //arragne
            MetricBmiCalculator metricBmiCalculator = new MetricBmiCalculator();

            //act 

            double result = metricBmiCalculator.CalculateBmi(weight, height);
            
            //assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        //   [InlineData(0,190)]
        // [InlineData(-50,150)]
        // [InlineData(-11,150)]
        //[InlineData(90,0)]
        // [InlineData(0, 0)]

        // [ClassData(typeof(MetricCalculatorTestData))]
        [JsonFileData("C:\\Users\\wales\\source\\repos\\AutomatedTests\\MyProject.Tests\\Data\\MetricBmiCalculatorData.json")]
        public void CalculateBmi_ForInvalidArguments_ThrowsArgumentException(double weight, double height)
        {

            //arragne
            MetricBmiCalculator metricBmiCalculator = new MetricBmiCalculator();

            //act 

            Action  action = () => metricBmiCalculator.CalculateBmi(weight, height);

            //assert - wyrzucenie wyjatku argument exeption
            Assert.Throws<ArgumentException>(action);
        }

    }
}
