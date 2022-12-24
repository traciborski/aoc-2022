var lines = File.ReadAllLines("input");
var Y = lines.Length;
var X = lines[0].Length;
var board = new char[Y, X];
char ELF = '#';

for (int y = 0; y < Y; y++)
    for (int x = 0; x < X; x++)
        board[y, x] = lines[y][x];

var round = 0;
while (true)
{
    Print(round);
    var propositions = Propose(round);
    var changed = MoveAll(propositions.ToArray());
    if (!changed) break;
    if (round == 10) break;
    round++;
}
Console.WriteLine(CountEmptyTiles());

int CountEmptyTiles()
{
    var (min_y, max_y, min_x, max_x, elfes) = MinMax();
    var total = (max_y - min_y + 1) * (max_x - min_x + 1);
    return total - elfes;
}
(int min_y, int max_y, int min_x, int max_x, int elfes) MinMax()
{
    int min_y = Y, max_y = 0, min_x = X, max_x = 0, elfes = 0;
    for (int y = 0; y < Y; y++)
        for (int x = 0; x < X; x++)
            if (board[y, x] == ELF)
            {
                elfes++;
                min_x = Math.Min(min_x, x);
                max_x = Math.Max(max_x, x);
                min_y = Math.Min(min_y, y);
                max_y = Math.Max(max_y, y);
            }
    return (min_y, max_y, min_x, max_x, elfes);
}

void Print(int round)
{
    Console.WriteLine("Round: " + round);
    for (int y = 0; y < Y; y++)
    {
        for (int x = 0; x < X; x++)
            Console.Write(board[y, x] == ELF ? ELF : '.');
        Console.WriteLine();
    }
    Console.WriteLine();
}

IEnumerable<(int y, int x, int dy, int dx)> Propose(int round)
{
    for (int y = 0; y < Y; y++)
        for (int x = 0; x < X; x++)
        {
            if (board[y, x] != ELF) continue;

            if (Free(y, x, 0, -1) && Free(y, x, -1, -1) && Free(y, x, -1, 0) && Free(y, x, -1, 1) &&
                Free(y, x, 0, 1) && Free(y, x, 1, 1) && Free(y, x, 1, 0) && Free(y, x, 1, -1))
                yield return (y, x, 0, 0);
            else if (GetCondition(round % 4, y, x))
                yield return GetConditionValue(round % 4, y, x);
            else if (GetCondition((round + 1) % 4, y, x))
                yield return GetConditionValue((round + 1) % 4, y, x);
            else if (GetCondition((round + 2) % 4, y, x))
                yield return GetConditionValue((round + 2) % 4, y, x);
            else if (GetCondition((round + 3) % 4, y, x))
                yield return GetConditionValue((round + 3) % 4, y, x);
            else
                yield return (y, x, 0, 0);
        }
}
bool GetCondition(int part, int y, int x)
{
    return part switch
    {
        0 => Free(y, x, -1, 0) && Free(y, x, -1, 1) && Free(y, x, -1, -1),
        1 => Free(y, x, 1, 0) && Free(y, x, 1, 1) && Free(y, x, 1, -1),
        2 => Free(y, x, 0, -1) && Free(y, x, 1, -1) && Free(y, x, -1, -1),
        3 => Free(y, x, 0, 1) && Free(y, x, 1, 1) && Free(y, x, -1, 1),
        _ => throw new NotImplementedException(),
    };
}
(int y, int x, int dy, int dx) GetConditionValue(int part, int y, int x)
{
    return part switch
    {
        0 => (y, x, -1, 0),
        1 => (y, x, 1, 0),
        2 => (y, x, 0, -1),
        3 => (y, x, 0, 1),
        _ => throw new NotImplementedException(),
    };
}
bool Free(int y, int x, int dy, int dx)
{
    var y2 = y + dy; var x2 = x + dx;
    if (y2 < 0) return true;
    if (x2 < 0) return true;
    if (y2 >= Y) return true;
    if (x2 >= X) return true;
    return board[y2, x2] != ELF;
}
bool MoveAll((int y, int x, int dy, int dx)[] moves)
{
    var changed = false;
    var (result, y_offset, x_offset) = NewBoard(moves);
    foreach ((int y, int x, int dy, int dx) in moves)
    {
        var y2 = y + dy;
        var x2 = x + dx;
        if (IsValid((y2, x2), moves) && (y2, x2) != (y, x))
        {
            result[y2 + y_offset, x2 + x_offset] = ELF;
            changed = true;
        }
        else
        {
            result[y + y_offset, x + x_offset] = ELF;
        }
    }
    board = result;
    return changed;
}

(char[,], int, int) NewBoard((int y, int x, int dy, int dx)[] moves)
{
    var y_min = Math.Min(0, moves.Select(m => m.y + m.dy).Min());
    var x_min = Math.Min(0, moves.Select(m => m.x + m.dx).Min());
    var y_max = Math.Max(Y - 1, moves.Select(m => m.y + m.dy).Max());
    var x_max = Math.Max(X - 1, moves.Select(m => m.x + m.dx).Max());
    X = x_max - x_min + 1;
    Y = y_max - y_min + 1;
    return (new char[Y, X], Math.Abs(y_min), Math.Abs(x_min));
}

(int, int) MoveOne((int y, int x, int dy, int dx) p)
{
    return (p.y + p.dy, p.x + p.dx);
}
bool IsValid((int y_to, int x_to) position, (int y, int x, int dy, int dx)[] propositions)
{
    var taken = false;
    foreach (var p in propositions)
        if (position == MoveOne(p))
            if (taken)
                return false;
            else
                taken = true;
    return true;
}