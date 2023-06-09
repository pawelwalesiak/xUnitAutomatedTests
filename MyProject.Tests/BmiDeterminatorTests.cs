﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tests
{
    public class BmiDeterminatorTests
    {
        [Theory]
        [InlineData(10.0,BmiClassification.Underweight)]
        [InlineData(18.0, BmiClassification.Underweight)]
        [InlineData(8.0, BmiClassification.Underweight)]
        [InlineData(19.0, BmiClassification.Normal)]
        [InlineData(21.0, BmiClassification.Normal)]
        [InlineData(24.0, BmiClassification.Normal)]
        [InlineData(28.0, BmiClassification.Overweight)]
        [InlineData(32.0, BmiClassification.Obesity)]
        [InlineData(54.0, BmiClassification.ExtremeObesity)]
        public void DeterminateDmi_ForGivenBmi_ReturnsCorrectCalssification(double bmi, BmiClassification classification) 
        {
            //arrange
            
            BmiDeterminator bmiDeterminator = new BmiDeterminator();
                 
            //act

            BmiClassification resutl = bmiDeterminator.DetermineBmi(bmi);
            
            //assert
            
            Assert.Equal(classification, resutl);


        }
        
    }
}
