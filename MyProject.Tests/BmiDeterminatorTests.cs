using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class BmiDeterminatorTests
    {
        [Theory]
        [InlineData(10.0)]
        [InlineData(17.0)]
        [InlineData(18.0)]
        [InlineData(8.0)]
        public void DeterminateDmi_ForBmiBelow18_ReturnsUnderweightCalssification(double bmi) 
        {
            //arrange
            
            BmiDeterminator bmiDeterminator = new BmiDeterminator();
            
            
            //act

            BmiClassification resutl = bmiDeterminator.DetermineBmi(bmi);
            
            //assert
            
            Assert.Equal(BmiClassification.Underweight, resutl);


        }
        
    }
}
