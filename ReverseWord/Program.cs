
var input = "ABCD 1234";
var result = Reverse(input);
Console.WriteLine(result);


string Reverse(string input)
{
    if (input.Length == 1) return input;

    var firstLetter = input.Substring(0, 1);
    var rest = input.Substring(1);
    var reversedRest = Reverse(rest);

    return reversedRest + firstLetter;
}