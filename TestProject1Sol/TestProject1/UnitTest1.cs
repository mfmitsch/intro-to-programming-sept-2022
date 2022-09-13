using System.Xml.Serialization;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 10, b = 20, answer;

            answer = a + b;

            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(10,20,30)]
        [InlineData(2,2,4)]
        [InlineData(10,5,15)]
        public void Addition(int a, int b, int expected)
        {
            int answer = a + b;
            Assert.Equal(expected, answer);
        }

        [Fact]
        public void DeterminingType()
        {
            // explicit variable declaration
            int x = 12;
            string str = "Mike";
            
            //implicit variable declaration
            var y = 12;
        }
    }
}