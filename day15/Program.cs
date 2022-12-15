using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input");
var map = new List<(int x, char sign)>();
var row = 2000000;
var beacon_found = false;
int beacon_x, beacon_y;

foreach (var line in lines)
{
    Console.WriteLine(line);
    var match = Regex.Match(line, @"Sensor at x=(\d+), y=(\d+): closest beacon is at x=(-*\d+), y=(-*\d+)");
    var sx = Parse(match, 1);
    var sy = Parse(match, 2);
    var bx = Parse(match, 3);
    var by = Parse(match, 4);
    MarkOnRow(sx, sy, bx, by);
}

int Parse(Match match, int i)
{
    return int.Parse(match.Groups[i].Value);
}

Console.WriteLine(map.Count(x => x.sign == 'X'));

void MarkOnRow(int sx, int sy, int bx, int by)
{
    beacon_x = bx;
    beacon_y = by;
    var radius = 1;
    beacon_found = false;
    while (true)
    {
        for (int i = 0; i <= radius; i++)
        {
            Mark(sx - radius, sy + i);
            Mark(sx - radius, sy - i);
            Mark(sx + radius, sy + i);
            Mark(sx + radius, sy - i);
            Mark(sx - i, sy + radius);
            Mark(sx - i, sy - radius);
            Mark(sx + i, sy + radius);
            Mark(sx + i, sy - radius);
        }
        if (beacon_found) return;
        radius++;
    }
}
void Mark(int x, int y)
{
    if (x == beacon_x && y == beacon_y)
    {
        beacon_found = true;
        return;
    }
    if (y == row)
    {
        if (!map.Any(a => a.x == x))
            map.Add((x, 'X'));
    }
}
int Increment(int x1, int x2)
{
    return x2.CompareTo(x1);
}