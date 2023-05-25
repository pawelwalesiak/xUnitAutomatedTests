using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit.Abstractions;

namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTest
    {

        public BmiCalculatorFacadeTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;   
        }
        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
        private const string NORMAL_SUMMARY = "Your weight is normal, keep it up";
        private readonly ITestOutputHelper _outputHelper;

        [Theory]
        [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
     //   [InlineData(BmiClassification.Overweight, NORMAL_SUMMARY)]
        
        public void GetResult_ForValidInput_ReturnsCorrectSummary(BmiClassification bmiClassification, string ExpectedResutl) 
        {

            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
            bmiDeterminatorMock.Setup(x => x.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);

            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);

          
            //act 
            BmiResult result  = bmiCalculatorFacade.GetResult(1,1);

            _outputHelper.WriteLine($"For classification {bmiClassification} result is {result.Summary}");
           
            //assert 
           // Assert.Equal(24.94, result.Bmi);
           //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
           // Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);

            //result.Bmi.Should().Be(24.93);
            //result.BmiClassification.Should().Be(BmiClassification.Overweight);
            result.Summary.Should().Be(ExpectedResutl);

        }
    }
}
