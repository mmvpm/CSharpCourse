namespace TreeSerialization;

public class Node
{
    public int Value { get; set; }
    
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString()
    {
        var leftString = Left == null ? "#" : Left.ToString();
        var rightString = Right == null ? "#" : Right.ToString();
        return "Node(" + Value + ", " + leftString + ", " + rightString +")";
    }
    
    public static Node? FromString(string source)
    {
        if (!source.StartsWith("Node(") || !source.EndsWith(")"))
            return null;

        source = source.Remove(0, "Node(".Length);
        source = source.Remove(source.Length - 1, ")".Length);

        var firstCommaIndex = source.IndexOf(',');
        if (firstCommaIndex == -1)
            return null;
        var valueString = source[..firstCommaIndex];
        var successfulParse = int.TryParse(valueString, out var value);
        if (!successfulParse)
            return null;
        source = source.Remove(0, firstCommaIndex + ", ".Length);

        var (leftString, rightString) = SplitStringIntoSubTrees(source);
        var leftNode = FromString(leftString);
        var rightNode = FromString(rightString);

        return new Node(value, leftNode, rightNode);
    }

    private static (string, string) SplitStringIntoSubTrees(string source)
    {
        var balance = 0;
        var commaIndex = -1;
        for (var i = 0; i < source.Length; ++i)
        {
            if (source[i] == '(')
                balance += 1;
            if (source[i] == ')')
                balance -= 1;
            if (balance == 0 && source[i] == ',')
            {
                commaIndex = i;
                break;
            }
        }
        if (commaIndex == -1)
            return ("#", "#");
        return (source[..commaIndex], source[(commaIndex + ", ".Length)..]);
    }
}
