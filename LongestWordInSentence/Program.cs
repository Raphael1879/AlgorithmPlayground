var input = "Hallo ich bin ein sehr langer Satzt";

var result = GetLongestWord(input);

Console.WriteLine("Longest word: " + result);



string GetLongestWord(string input)
{
    string[] words = input.Split(" ");

    var longestWord = "";
    foreach (var word in words)
    {
        if (word.Length > longestWord.Length)
            longestWord = word;

    }

    return longestWord;
}