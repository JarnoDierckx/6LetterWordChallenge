using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge
{
    public class CombinationFinder
    {
        private readonly List<string> _words;
        public CombinationFinder(string filePath)
        {
            _words = File.ReadAllLines(filePath).ToList();
        }

        public IEnumerable<string> FindWordCombinations()
        {
            var combinations = new List<string>();

            foreach (var word1 in _words)
            {
                foreach (var word2 in _words)
                {
                    if (word1.Length + word2.Length == 6 && _words.Contains(word1 + word2))
                    {
                        string sixLetterWord = $"{word1}+{word2}={word1}{word2}";
                        if (!combinations.Contains(sixLetterWord))
                        {
                            combinations.Add(sixLetterWord);
                        }
                        
                    } else if(word2.Length + word1.Length == 6 && _words.Contains(word2 + word1)){
                        string sixLetterWord = $"{word2}+{word1}={word2}{word1}";
                        if (!combinations.Contains(sixLetterWord))
                        {
                            combinations.Add(sixLetterWord);
                        }
                    }
                }
            }

            return combinations;
        }
        public IEnumerable<string> FindWordCombinationsRecursively()
        {
            var combinations = new List<string>();
            FindCombinations(combinations);
            return combinations;
        }

        private void FindCombinations(List<string> combinations, List<string> currentCombination = null, int lengthSoFar = 0)
        {
            if (currentCombination == null)
            {
                currentCombination = new List<string>();
            }

            foreach (var word in _words)
            {
                List<string> newCombination = new List<string>(currentCombination);
                newCombination.Add(word);
                int newLength = lengthSoFar + word.Length;

                if (newLength == 6 && newCombination.Count >= 2)
                {
                    string combinedWord = string.Join("", newCombination);
                    if (_words.Contains(combinedWord))
                    {
                        string combinationString = string.Join("+", newCombination);
                        combinationString = combinationString + "=" + combinedWord;
                        if  (!combinations.Contains(combinationString))
                        {
                            combinations.Add(combinationString);
                            Console.WriteLine(combinationString);
                        }
                        
                    }
                }
                else if (newLength < 6)
                {
                    FindCombinations(combinations, newCombination, newLength);
                }
            }
        }

        /*public IEnumerable<string> FindWordCombinationsParallel()
        {
            var combinations = new List<string>();
            var lockObj = new object();

            Parallel.ForEach(_words, word =>
            {
                FindCombinations2(word, combinations, lockObj);
            });

            return combinations;
        }

        private void FindCombinations2(string startWord,  List<string> combinations, object lockObj, List<string> currentCombination = null, int lengthSoFar = 0)
        {
            if (currentCombination == null)
            {
                currentCombination = new List<string>();
            }

            foreach (var word in _words)
            {
                List<string> newCombination = new List<string>(currentCombination);
                newCombination.Add(word);
                int newLength = lengthSoFar + word.Length;

                if (newLength == 6 && newCombination.Count >= 2)
                {
                    string combinedWord = string.Join("+", newCombination);
                    if (_words.Contains(combinedWord) && !combinations.Contains(combinedWord))
                    {
                        lock (lockObj)
                        {
                            combinations.Add($"{combinedWord}={startWord}");
                            Console.WriteLine($"{combinedWord}={startWord}");
                        }
                    }
                }
                else if (newLength < 6)
                {
                    FindCombinations2(startWord, combinations, lockObj, newCombination, newLength);
                }
            }
        }*/
    }
}
