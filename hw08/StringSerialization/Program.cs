using System.Text;

string Identity(string s)
{
    var bytes = Encoding.UTF8.GetBytes(s);
    var newS = Encoding.UTF8.GetString(bytes);
    return newS;
}

const string russianString = "Строчка на русском языке";
const string germanString = "Das ist nur eine Straße";
const string japaneseString = "あなたは多くの価値があります。";

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine(Identity(russianString));
Console.WriteLine(Identity(russianString) == russianString); // True

Console.WriteLine(Identity(germanString));
Console.WriteLine(Identity(germanString) == germanString); // True

Console.WriteLine(Identity(japaneseString));
Console.WriteLine(Identity(japaneseString) == japaneseString); // True
