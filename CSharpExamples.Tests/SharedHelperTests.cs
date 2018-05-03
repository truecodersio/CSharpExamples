using Xunit;
using CSharpExamples;
using CSharpExamples.Shared;

namespace CSharpExamples.Tests
{
    public class SharedHelperTests
    {
        // Arrange
        [Theory]
        [InlineData(1, 0, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(2, 1, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(3, 2, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(4, 3, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, 4, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(1, 0, new[] { 1, 2, 3, 4 })]
        [InlineData(2, 1, new[] { 1, 2, 3, 4 })]
        [InlineData(3, 2, new[] { 1, 2, 3, 4 })]
        [InlineData(4, 3, new[] { 1, 2, 3, 4 })]
        public void BinarySearchFound(int value, int expected, int[] arr)
        {
            // Act
            var actual = arr.BinarySearch(value);

            // Assert;
            Assert.Equal(expected, actual);
        }

        // Arrange
        [Theory]
        [InlineData(6, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(5, new[] { 1, 2, 3, 4 })]
        [InlineData(0, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(0, new[] { 1, 2, 3, 4 })]
        public void BinarySearchNotFound(int value, int[] arr)
        {
            // Act
            var actual = arr.BinarySearch(value);

            // Assert;
            Assert.Equal(-1, actual);
        }
    }
}
