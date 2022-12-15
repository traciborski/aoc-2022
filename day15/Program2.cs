using System.Text.RegularExpressions;

var lines = File.ReadAllLines("input");
var size = 4_000_000;
var map = new Dictionary<int, List<(int from, int to)>>();
for (var i = 0; i <= size; i++) map.Add(i, new List<(int x, int y)>());

foreach (var line in lines)
{
    var match = Regex.Match(line, @"Sensor at x=(\d+), y=(\d+): closest beacon is at x=(-*\d+), y=(-*\d+)");
    var sx = Parse(match, 1);
    var sy = Parse(match, 2);
    var bx = Parse(match, 3);
    var by = Parse(match, 4);

    var d = Math.Abs(bx - sx) + Math.Abs(by - sy);

    for (int y = Math.Max(0, sy - d); y <= Math.Min(sy + d, size); y++)
    {
        var (x_min, x_max) = MinMax(sx, sy, d, y);
        map[y].Add((x_min, x_max));
    }
}
for (int y = 0; y <= map.Count; y++)
{
    map[y] = map[y].OrderBy(x => x.from).ToList();
    var r = 0;
    for (int x = 0; x < map[y].Count; x++)
    {
        if (map[y][x].from > r)
        {
            Console.WriteLine(4_000_000 * (map[y][x].from - 1) + y);
            return;
        }
        else
        {
            r = Math.Max(r, map[y][x].to);
        }
    }
}

int Parse(Match match, int i) => int.Parse(match.Groups[i].Value);

(int min, int max) MinMax(int sx, int sy, int d, int y) // min max x on Y to mark X
{
    var dy = Math.Abs(y - sy);
    var x1 = sx - d + dy;
    var x2 = sx + d - dy;
    return (Math.Min(x1, x2), Math.Max(x1, x2));
}
