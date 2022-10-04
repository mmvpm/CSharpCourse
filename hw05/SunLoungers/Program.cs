int SunLoungers(string input)
{
    return ("0" + input + "0")
        .Split("1")
        .Select(line => line.Length)
        .Where(len => len != 0)
        .Select(len => Math.Max(0, len - 1) / 2).Sum();
}

var inputs = new List<string>
{
    "1",
    "0",
    "00",
    "000",
    "00000",
    "10001",
    "00101",
    "0101010",
    "001000011"
};

inputs.ForEach(input =>
    Console.WriteLine("SunLoungers(" + input + ") = " + SunLoungers(input))
);
/*
    SunLoungers(1) = 0
    SunLoungers(0) = 1
    SunLoungers(00) = 1
    SunLoungers(000) = 2
    SunLoungers(00000) = 3
    SunLoungers(10001) = 1
    SunLoungers(00101) = 1
    SunLoungers(0101010) = 0
    SunLoungers(001000011) = 2
*/