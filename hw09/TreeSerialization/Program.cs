using TreeSerialization;

var tree = new Node(
    1,
    new Node(
        2,
        new Node(3),
        new Node(4)),
    new Node(
        5,
        new Node(
            6,
            new Node(7),
            new Node(8)),
        new Node(9)));

var treeString = tree.ToString();
Console.WriteLine(treeString); 
// Node(1, Node(2, Node(3, #, #), Node(4, #, #)), Node(5, Node(6, Node(7, #, #), Node(8, #, #)), Node(9, #, #)))

var copiedTree = Node.FromString(treeString);
Console.WriteLine(copiedTree);
// Node(1, Node(2, Node(3, #, #), Node(4, #, #)), Node(5, Node(6, Node(7, #, #), Node(8, #, #)), Node(9, #, #)))
