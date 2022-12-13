var lines = await File.ReadAllLinesAsync("input");
var adds = new int[lines.Count() * 2];
var checkpoints = new[] { 20, 60, 100, 140, 180, 220 };
var result = 0;
var x = 1; // register
var cycle = 0;
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var command = Parse(line);
    cycle += command.cycles;
    adds[cycle] = command.value;
}

var registers = new int[adds.Length];
for (int i = 0; i < adds.Length; i++)
{
    x += adds[i];
    registers[i] = x;
    if (checkpoints.Contains(i + 1))
        result += (i + 1) * x;
}

Console.WriteLine(result);
Console.WriteLine();

for (int i = 0; i < adds.Length; i++)
{
    var pos_x = i % 40;
    if (pos_x == 0)
        Console.WriteLine();
    var visible = Visible(registers[i], pos_x);
    Console.Write(visible ? 'X' : '.');
}

bool Visible(int middle, int pos)
{
    return middle - 1 <= pos && pos <= middle + 1;
}

(int value, int cycles) Parse(string line)
{
    if (line == "noop") return (0, 1);
    return (int.Parse(line.Split(" ")[1]), 2);
}