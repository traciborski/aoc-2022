using System.Text.RegularExpressions;

var Y = 2000000;

var lines = File.ReadAllLines("input");
var map = new Dictionary<int, char>();

foreach (var line in lines)
{
    var match = Regex.Match(line, @"Sensor at x=(\d+), y=(\d+): closest beacon is at x=(-*\d+), y=(-*\d+)");
    var sx = Parse(match, 1);
    var sy = Parse(match, 2);
    var bx = Parse(match, 3);
    var by = Parse(match, 4);
    if (by == Y) Map(bx, 'B');
    var d = Math.Abs(bx - sx) + Math.Abs(by - sy);
    var (x_min, x_max) = MinMax(sx, sy, d);
    for (int x = x_min; x <= x_max; x++)
        Map(x, 'X');
}

Console.WriteLine(map.Count(x => x.Value == 'X'));
int Parse(Match match, int i) => int.Parse(match.Groups[i].Value);

(int min, int max) MinMax(int sx, int sy, int d) // min max x on Y to mark X
{
    var dy = Math.Abs(Y - sy);
    var x1 = sx - d + dy;
    var x2 = sx + d - dy;
    return (Math.Min(x1, x2), Math.Max(x1, x2));
}
void Map(int x, char c)
{
    if (!map.ContainsKey(x))
        map[x] = c;
    else if (c != 'X') // beacon and sensor can overide, X can't
        map[x] = c;
}