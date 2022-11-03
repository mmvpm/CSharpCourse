using System.Text;

const long n = 100_000_000;
const int numberLength = 8;

using Stream s = new FileStream("numbers.txt", FileMode.Create);
for (long i = 0; i < n; ++i)
{
    var number = (i * 47907813L + 29763927L) % n;
    var line = number.ToString();
    line = new string('0', numberLength - line.Length) + line + "\n";
    s.Write(Encoding.ASCII.GetBytes(line));
}