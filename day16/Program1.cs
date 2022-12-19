using System.Text.RegularExpressions;
var lines = File.ReadAllLines("input0");
var valves = new Valve[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var match = Regex.Match(line, @"Valve (.+) has flow rate=(.+); tunnels* leads* to valves* (.+)");
    valves[i] = new Valve(i, match.Groups[1].Value, int.Parse(match.Groups[2].Value), match.Groups[3].Value.Split(", "));
}
var threshold = 20;
var open = new bool[valves.Length];

foreach (var valve in valves) if(valve.Rate==0)open[valve.Index]=true;

Console.WriteLine($"{Traverse(valves[0], 0, 0, open)}");

var visited = new HashSet<bool[]>();

int Traverse(Valve valve, int local_max, int time, bool[] open)
{
    time++;

    var diff = 0;
    foreach (var v in valves)
        if (open[v.Index])
            diff += v.Rate;

    Console.WriteLine(diff);
    local_max += diff;

    if (time >= threshold)
        return local_max;

    var results = new List<int>();

    if (open.Any(x => !x))
        foreach (var v in valve.Other)
            results.Add(Traverse(valves.First(x => x.Name == v), local_max, time, open.ToArray()));

    if (!open[valve.Index] && valve.Rate > 0)
    {
        open[valve.Index] = true;
        results.Add(Traverse(valve, local_max, time, open.ToArray()));
    }

    if (!results.Any())
    {
        results.Add(local_max);
    }
    return results.Max();
}

record Valve(int Index, string Name, int Rate, string[] Other);