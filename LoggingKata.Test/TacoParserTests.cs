using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("0,0,Taco Test")]
        [InlineData("-90,-90, Taco Test")]
        [InlineData("90,90,Taco Test")]

        public void ShouldParse(string str)
        {
            //arrange
            TacoParser tacoParser = new TacoParser();

            //act 
            ITrackable actual = tacoParser.Parse(str);

            // Assert 
            Assert.NotNull(actual);
            Assert.NotNull(actual.Location);
            Assert.NotNull(actual.Name);
            Assert.NotNull(actual.Name.Length > 0);
        }






        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("0, Taco Test")]
        [InlineData("0, abc,Taco Test")]
        [InlineData("abc,0,Taco Test")]
        public void ShouldFailParse(string str)
        {
            // Arrange 
            TacoParser tacoParser = new TacoParser();

            //Act
            ITrackable actual = tacoParser.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}
