using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class BmiCalculatorFacadeTest
    {
        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";

        [Fact]
        public void GetResult_ForValidInput_ReturnsCorrectResult() 
        {



            var bmiDeterminatorMock = new Mock<IBmiDeterminator>();
            bmiDeterminatorMock.Setup(x => x.DetermineBmi(It.IsAny<double>())).Returns(BmiClassification.Overweight);

            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeterminatorMock.Object);

            double weight = 90;
            double height = 190;

            //act 
            BmiResult result  = bmiCalculatorFacade.GetResult(weight, height);

            //assert 
            Assert.Equal(24.94, result.Bmi);
            Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            Assert.Equal(OVERWEIGHT_SUMMARY, result.Summary);

        }
    }
}
