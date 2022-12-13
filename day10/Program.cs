var lines = await File.ReadAllLinesAsync("input");
var adds = new int[lines.Count() + 2];
var checkpoints = new[] { 20, 60, 100, 140, 180, 220 };
//var checkpoints = new[] { 7 }; // 
var result = 0;
var x = 1; // register
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var command = Parse(line);
    adds[i + command.cycles] += command.value;
}
for (int i = 0; i < adds.Length; i++)
{
    if (checkpoints.Contains(i + 1))
        result += (i + 1) * x;
    
    x += adds[i];
}
// 32980 too high
// 10760 too low
Console.WriteLine(result);
(int value, int cycles) Parse(string line)
{
    if (line == "noop") return (0, 1);
    return (int.Parse(line.Split(" ")[1]), 2);
}