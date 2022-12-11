var lines = await File.ReadAllLinesAsync("input");
var size = 10; // 2 for part 1 
var x = new (int, int)[size];
var visited = new HashSet<(int, int)> { x[size - 1] };
foreach (var line in lines)
{
    var words = line.Split(' ');
    var direction = words[0];
    var steps = int.Parse(words[1]);

    while (steps > 0)
    {
        x[0] = Move(direction, x[0]);
        steps--;
        for (var i = 0; i < size - 1; i++)
        {
            if (!AreClose(x[i], x[i + 1]))
            {
                x[i + 1] = MoveToward(x[i + 1], x[i]);
                if (i == size - 2) visited.Add(x[i + 1]);
            }
        }
    }
}
Console.WriteLine(visited.Count);

(int, int) MoveToward((int x, int y) t, (int x, int y) h)
{
    return (t.x - t.x.CompareTo(h.x), t.y - t.y.CompareTo(h.y));
}

(int, int) Move(string direction, (int x, int y) h)
{
    if (direction == "D") return (h.x, h.y + 1);
    if (direction == "U") return (h.x, h.y - 1);
    if (direction == "L") return (h.x - 1, h.y);
    if (direction == "R") return (h.x + 1, h.y);
    throw new NotImplementedException();
}

bool AreClose((int x, int y) h, (int x, int y) t)
{
    return Math.Abs(h.x - t.x) <= 1 && Math.Abs(h.y - t.y) <= 1;
}