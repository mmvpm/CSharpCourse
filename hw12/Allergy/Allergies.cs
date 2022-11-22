namespace Allergy;

public class Allergies
{
    public string Name { get; }

    public int Score { get; set; }

    public Allergies(string name)
    {
        Name = name;
        Score = 0;
    }

    public Allergies(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public Allergies(string name, string allergies)
    {
        Name = name;
        Score = ScoreFromString(allergies);
    }

    public override string ToString()
    {
        if (Score == 0)
            return Name + " doesn't have allergies.";
        return Name + " is allergic to: " + AllergiesToString(AllergensFromScore(Score)) + ".";
    }

    public bool IsAllergicTo(Allergen allergen) =>
        AllergensFromScore(Score).Contains(allergen);

    public bool IsAllergicTo(string allergen) =>
        IsAllergicTo(ParseAllergen(allergen));

    public void AddAllergy(Allergen allergen) =>
        Score += (int) allergen;
    
    public void AddAllergy(string allergen) =>
        AddAllergy(ParseAllergen(allergen));
    
    public void DeleteAllergy(Allergen allergen) =>
        Score -= (int) allergen;
    
    public void DeleteAllergy(string allergen) =>
        DeleteAllergy(ParseAllergen(allergen));

    // internal

    private static int ScoreFromString(string allergiesString) =>
        allergiesString
            .Split(" ")
            .Sum(allergenString => (int) ParseAllergen(allergenString));

    private static List<Allergen> AllergensFromScore(int score)
    {
        var result = new List<Allergen>();
        for (var allergyValue = (int)Allergen.Unknown; allergyValue > 0; allergyValue /= 2)
        {
            if (score - allergyValue < 0)
                continue;
            score -= allergyValue;
            result.Add((Allergen)allergyValue);
        }
        result.Reverse();
        return result;
    }

    private static string AllergiesToString(List<Allergen> allergens) =>
        string.Join(", ", allergens);

    private static Allergen ParseAllergen(string allergenString) =>
        Enum.TryParse(allergenString, out Allergen allergy) ? allergy : Allergen.Unknown;
}