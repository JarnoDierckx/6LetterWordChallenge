using _6LetterWordChallenge;

class Program
{
    static void Main()
    {

        string filePath = "C:/Users/jarno/source/repos/6LetterWordChallenge/input.txt";
        var finder = new CombinationFinder(filePath);

        //var combinations = finder.FindWordCombinations();
        var combinations = finder.FindWordCombinationsRecursively();

        foreach (var combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }
}
