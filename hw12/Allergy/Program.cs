using Allergy;

var mary = new Allergies("Mary");
Console.WriteLine(mary); // Mary doesn't have allergies.

var joe = new Allergies("Joe", 65);
Console.WriteLine(joe); // Joe is allergic to: Eggs, FlowerPollen.

var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");
Console.WriteLine(rob); // Rob is allergic to: Peanuts, Strawberries, Chocolate, Cats.

Console.WriteLine(rob.IsAllergicTo(Allergen.Peanuts)); // True
Console.WriteLine(rob.IsAllergicTo("Peanuts")); // True
Console.WriteLine(rob.IsAllergicTo("FlowerPollen")); // False

rob.AddAllergy(Allergen.FlowerPollen);
Console.WriteLine(rob.IsAllergicTo("FlowerPollen")); // True

rob.DeleteAllergy("FlowerPollen");
Console.WriteLine(rob.IsAllergicTo(Allergen.FlowerPollen)); // False
