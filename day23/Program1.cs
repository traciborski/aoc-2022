var lines = File.ReadAllLines("input0");
var Y = lines.Length;
var X = lines[0].Length;
var board = new char[Y, X];
char ELF = '#';

for (int y = 0; y < Y; y++)
    for (int x = 0; x < X; x++)
        board[y, x] = lines[y][x];

while (true)
{
    Print();
    var propositions = Propose();
    var changed = MoveAll(propositions);
    if (!changed) break;
}

void Print()
{
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

            if (Free(y, x, -1, 0) && Free(y, x, -1, 1) && Free(y, x, -1, -1))
                yield return (y, x, -1, 0);
            else if (Free(y, x, 1, 0) && Free(y, x, 1, 1) && Free(y, x, 1, -1))
                yield return (y, x, 1, 0);
            else if (Free(y, x, 0, -1) && Free(y, x, 1, -1) && Free(y, x, -1, -1))
                yield return (y, x, 0, -1);
            else if (Free(y, x, 0, 1) && Free(y, x, 1, 1) && Free(y, x, -1, 1))
                yield return (y, x, 0, 1);
            else
                yield return (y, x, 0, 0);
        }
}
bool Free(int y, int x, int dy, int dx)
{
    var y2 = y + dy; var x2 = x + dx;
    if (y2 < 0) return false;
    if (x2 < 0) return false;
    if (y2 >= Y) return false;
    if (x2 >= X) return false;
    return board[y2, x2] != ELF;
}
bool MoveAll(IEnumerable<(int y, int x, int dy, int dx)> moves)
{
    var changed = false;
    var result = new char[Y, X];
    foreach ((int y, int x, int dy, int dx) in moves)
    {
        var y2 = y + dy;
        var x2 = x + dx;
        if (IsValid((y2, x2), moves))
        {
            result[y2, x2] = ELF;
            changed = true;
        }
        else
        {
            result[y, x] = ELF;
        }
    }
    board = result;
    return changed;
}
(int, int) MoveOne((int y, int x, int dy, int dx) p)
{
    return (p.y + p.dy, p.x + p.dx);
}
bool IsValid((int y_to, int x_to) position, IEnumerable<(int y, int x, int dy, int dx)> propositions)
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