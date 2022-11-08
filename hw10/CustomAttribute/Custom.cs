namespace CustomAttribute;

public class Custom : Attribute 
{
    public string AuthorName { get; }
    public int RevisionNumber { get; }
    public string Description { get; }
    public string[] Reviewers { get; }

    public Custom(string authorName, int revisionNumber, string description, params string[] reviewers)
    {
        AuthorName = authorName;
        RevisionNumber = revisionNumber;
        Description = description;
        Reviewers = reviewers;
    }

    public override string ToString()
    {
        return "Custom(" + AuthorName + ", " + RevisionNumber + ", " + Description + ", [" + string.Join(", ", Reviewers) + "])";
    }
}