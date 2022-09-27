using Hamsters;

var hamsters = Enumerable
    .Repeat(0, 5)
    .Select(_ => Hamster.CreateRandom())
    .ToList();

Console.WriteLine("Before");
hamsters.ForEach(hamster => Console.WriteLine("  - " + hamster));

hamsters.Sort();

Console.WriteLine("\nAfter");
hamsters.ForEach(hamster => Console.WriteLine("  - " + hamster));

/*
Before
  - Hamster(286, 0,686, 0,226, 0,775)
  - Hamster(226, 0,514, 0,003, 0,744)
  - Hamster(10, 0,341, 0,905, 0,525)
  - Hamster(241, 0,209, 0,392, 0,924)
  - Hamster(87, 0,708, 0,303, 0,794)

After
  - Hamster(10, 0,341, 0,905, 0,525)
  - Hamster(87, 0,708, 0,303, 0,794)
  - Hamster(226, 0,514, 0,003, 0,744)
  - Hamster(241, 0,209, 0,392, 0,924)
  - Hamster(286, 0,686, 0,226, 0,775)
*/