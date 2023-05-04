using System.Text;

namespace MyProject.Tests
{
    public class StringBuilderTests

    {
        [Fact]
        public void Append_ForTwoStrings_ReturnsConcatnenatedString()
        {
            //arrange

            StringBuilder sb = new StringBuilder();
           
            //act

            sb.Append("test")
                .Append("test20");

            string result = sb.ToString();
             

            //assert

            Assert.Equal("testtest20", result);
           

        }
    }
}