using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class MetricCalculatorBmiTests
    {
        [Theory]
        [InlineData(100, 170, 34.6)]
        [InlineData(57, 170, 19.72)]
        [InlineData(70, 170, 24.22)]
        public void CalculateBmi_ForgivenWightAndHeidht_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        { 
            //arragne
            MetricBmiCalculator metricBmiCalculator = new MetricBmiCalculator();

            //act 

            double result = metricBmiCalculator.CalculateBmi(weight, height);
            
            //assert
            Assert.Equal(bmiResult, result);
        }
    }
}
