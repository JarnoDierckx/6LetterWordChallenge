using _6LetterWordChallenge;

class Program
{
    static void Main()
    {

        string filePath = "../../../input.txt";
        var finder = new CombinationFinder(filePath);

        var combinations = finder.FindWordCombinations();                       //combinations with two words
        //var combinations = finder.FindWordCombinationsRecursively();          //combinations with more than two words

        foreach (var combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }
}
