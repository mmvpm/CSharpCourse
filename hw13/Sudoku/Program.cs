bool CheckSudoku(List<List<string>> sudoku)
{
    bool CheckList(List<string> numbers)
    {
        var numberList = numbers.Where(number => number != ".").ToList();
        var inRange = numberList
            .Select(number => int.TryParse(number, out var result) ? result : -1)
            .All(number => number is >= 1 and <= 9);
        var noDuplicates = new HashSet<string>(numberList).Count == numberList.Count;
        return noDuplicates && inRange;
    }

    bool CheckRow(int rowIndex) =>
        CheckList(sudoku[rowIndex]);

    bool CheckColumn(int columnIndex) =>
        CheckList(sudoku.Select(row => row[columnIndex]).ToList());

    bool CheckBlock(int rowIndex, int columnIndex) =>
        CheckList(sudoku
            .Skip(rowIndex * 3).Take(3)
            .SelectMany(row => row.Skip(columnIndex * 3).Take(3).ToList()).ToList());

    var rowResults = Enumerable.Repeat(false, sudoku.Count).ToList();
    var columnResults = Enumerable.Repeat(false, sudoku[0].Count).ToList();
    var blockResults = Enumerable.Repeat(false, sudoku[0].Count).ToList();

    var threads = new List<Thread>();
    for (var i = 0; i < sudoku.Count; ++i)
    {
        var rowIndex = i;
        var columnIndex = i;
        var blockRow = i / 3;
        var blockColumn = i % 3;

        threads.Add(new Thread(_ => 
            rowResults[rowIndex] = CheckRow(rowIndex)));

        threads.Add(new Thread(_ => 
            columnResults[columnIndex] = CheckColumn(columnIndex)));
        
        threads.Add(new Thread(_ => 
            blockResults[blockRow * 3 + blockColumn] = CheckBlock(blockRow, blockColumn)));
    }
    
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());

    var rowResult = rowResults.All(a => a);
    var columnResult = columnResults.All(a => a);
    var blockResult = blockResults.All(a => a);

    return rowResult && columnResult && blockResult;
}

var sudoku1 = new List<List<string>>
{
    new() {"5","3",".",".","7",".",".",".","."},
    new() {"6",".",".","1","9","5",".",".","."},
    new() {".","9","8",".",".",".",".","6","."},
    new() {"8",".",".",".","6",".",".",".","3"},
    new() {"4",".",".","8",".","3",".",".","1"},
    new() {"7",".",".",".","2",".",".",".","6"},
    new() {".","6",".",".",".",".","2","8","."},
    new() {".",".",".","4","1","9",".",".","5"},
    new() {".",".",".",".","8",".",".","7","9"}
};
Console.WriteLine(CheckSudoku(sudoku1)); // True

var sudoku2 = new List<List<string>>
{
    new() {"8","3",".",".","7",".",".",".","."},
    new() {"6",".",".","1","9","5",".",".","."},
    new() {".","9","8",".",".",".",".","6","."},
    new() {"8",".",".",".","6",".",".",".","3"},
    new() {"4",".",".","8",".","3",".",".","1"},
    new() {"7",".",".",".","2",".",".",".","6"},
    new() {".","6",".",".",".",".","2","8","."},
    new() {".",".",".","4","1","9",".",".","5"},
    new() {".",".","6",".","8",".",".","7","9"}
};
Console.WriteLine(CheckSudoku(sudoku2)); // False
