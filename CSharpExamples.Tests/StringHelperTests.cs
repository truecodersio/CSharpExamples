using Xunit;
using CSharpExamples;

namespace CSharpExamples.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void EmptyStringIsInvalidEmail()
        {
            // Arrange
            var email = "";

            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.False(result);
        }

        // Arrange
        [Theory]
        [InlineData("cwinton@truecoders.io")]
        [InlineData("dwalsh@truecoders.io")]
        [InlineData("me@example.com")]
        public void IsValidEmail(string email)
        {
            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.True(result);
        }

        // Arrange
        [Theory]
        [InlineData("cwinton")]
        [InlineData("dwalsh@s.i")]
        [InlineData("me@1.2")]
        public void IsInvalidEmail(string email)
        {
            // Act
            var result = email.IsValidEmail();

            // Assert
            Assert.True(result);
        }
    }
}
