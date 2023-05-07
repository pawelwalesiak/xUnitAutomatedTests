using FluentAssertions;
using Moq;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Service.Tests
{

    public class ResultServiceTests
    {
        [Fact]
        public void SetRecentOverweightResult_ForOverweightResult_UpdatesProperty()
        {
            //arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Overweight };
            var resultRepository = new FakeResultRepository();
            var resultService = new ResultService(resultRepository);

            //act 
            resultService.SetRecentOverweightResult(result);

            //assert
            resultService.RecentOverweightResult.Should().Be(result);
        }

        private class FakeResultRepository : IResultRepository
        {
            private BmiResult _result;

            public Task SaveResultAsync(BmiResult result)
            {
                _result = result;
                return Task.CompletedTask;
            }

            public Task<BmiResult> GetLatestResultAsync()
            {
                return Task.FromResult(_result);
            }
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
        {
            //arragne
            var result = new BmiResult { BmiClassification = BmiClassification.Underweight };

            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);
            
            //act 
            await resultService.SaveUnderweightResultAsync(result);

            //assert
            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);

        }
        [Fact]
        public async Task SaveUnderweightResultAsync_ForNonUnderweightResult_InvokesSaveResultAsync()
        {
            //arragne
            var result = new BmiResult { BmiClassification = BmiClassification.Normal };

            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);

            //act 
            await resultService.SaveUnderweightResultAsync(result);

            //assert
            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);

        }
    }
}