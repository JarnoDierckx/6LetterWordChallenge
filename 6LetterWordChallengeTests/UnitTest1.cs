using _6LetterWordChallenge;

namespace _6LetterWordChallengeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindWordCombinations_ReturnsExpectedCombinations()
        {
            // Arrange
            var filePath = "test_input.txt";
            File.WriteAllLines(filePath, ["fo", "obar", "foobar"]);

            var finder = new CombinationFinder(filePath);

            // Act
            var combinations = finder.FindWordCombinations();

            // Assert
            Assert.AreEqual(1, combinations.Count());

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public void FindWordCombinationsRecursively_ReturnsExpectedCombinations()
        {
            // Arrange
            var filePath = "test_input.txt";
            File.WriteAllLines(filePath, ["fo", "obar", "f", "o", "foobar"]);

            var finder = new CombinationFinder(filePath);

            // Act
            var combinations = finder.FindWordCombinationsRecursively();

            // Assert
            Assert.AreEqual(2, combinations.Count());

            // Cleanup
            File.Delete(filePath);
        }
    }
}