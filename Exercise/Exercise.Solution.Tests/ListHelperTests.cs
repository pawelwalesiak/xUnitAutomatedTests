using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Exercise.Solution.Tests
{
    public class ListHelperTests
    {
        [Fact]
       
        public void FilterOddNumber_ReturnEvenList_ReturnEvenNumbers() 
        {
            //act 

            //arrange

            List<int> input = new List<int>() { 1,2,2,3,5,7,9,8,2};  
            List<int> expected = new List<int>() {1,3,5,7,9 };
            //assert
           List<int> result =  ListHelper.FilterOddNumber(input);
          // Assert.Equal(expected, result);
            result.Should().Equal(expected);
        }
    }
}
