var lines = await File.ReadAllLinesAsync("input");
var width = 600;
var height = 200;
var board = new char[width, height]; // x,y
var rock = 'X';
var air = '\0';

foreach (var line in lines)
{
    var coordinates = line.Split(" -> ").Select(c => (int.Parse(c.Split(',')[0]), int.Parse(c.Split(',')[1]))).ToArray();
    Rocks(coordinates);
}

int xmax = 0, ymax = 0, xmin = 1000, ymin = 1000;
for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if (board[x, y] != air)
        {
            xmax = Math.Max(xmax, x);
            ymax = Math.Max(ymax, y);
            xmin = Math.Min(xmin, x);
            ymin = Math.Min(ymin, y);
        }
    }
}
var counter = 0;
(int x, int y) sand = (500, 0);

Move();
Print();
Console.WriteLine(counter);

void Move()
{
    while (NewSand())
    {
        if (MoveSand())
        {
            board[sand.x, sand.y] = 'o';
            counter++;
        }
        else
        {
            return;
        }
    }
}
bool MoveSand()
{
    var moved = false; // moved at all 
    while (true)
    {
        if (TryMove(0, 1)) moved = true; // down
        else if (TryMove(-1, 1)) moved = true; // down left
        else if (TryMove(1, 1)) moved = true; // down right
        else return moved;
    }
}

bool TryMove(int dx, int dy)
{
    var x = sand.x + dx;
    var y = sand.y + dy;
    if (x <= xmin) return false;
    if (x >= xmax) return false;
    if (y < 0) return false;
    if (y > ymax) return false;
    var result = board[x, y] == air;
    if (result) sand = (x, y);
    return result;
}

bool NewSand()
{
    sand = (500, 0);
    return true;
}
void Rocks((int x, int y)[] cs)
{
    for (int i = 1; i < cs.Length; i++)
        Line(cs[i - 1], cs[i]);
}
void Line((int x, int y) from, (int x, int y) to)
{
    var dx = Increment(from.x, to.x);
    var dy = Increment(from.y, to.y);
    var cursor = from;
    while (cursor != to)
    {
        board[cursor.x, cursor.y] = rock;
        cursor = (cursor.x + dx, cursor.y + dy);
    }
}
int Increment(int x1, int x2)
{
    return x2.CompareTo(x1);
}
void Print()
{
    for (int y = 0; y <= ymax; y++)
    {
        Console.Write($"{y}. ");
        for (int x = xmin; x <= xmax; x++)
        {
            var c = board[x, y];
            if (c == air)
                c = '.';
            Console.Write(c);
        }
        Console.WriteLine();
    }
}
