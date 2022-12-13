var lines = await File.ReadAllLinesAsync("input");
var monkeys = new List<Monkey>();
var index = 0;
foreach (var line in lines)
{
    if (line == "")
    {
        index++;
    }
    else if (line.StartsWith("Monkey "))
    {
        monkeys.Add(new Monkey());
    }
    else if (line.StartsWith("  Starting items: "))
    {
        monkeys[index].Items.AddRange(line.Replace("  Starting items: ", "").Split(", ").Select(long.Parse));
    }
    else if (line.StartsWith("  Test: divisible by "))
    {
        monkeys[index].Test = long.Parse(line.Replace("  Test: divisible by ", ""));
    }
    else if (line.StartsWith("    If true: throw to monkey "))
    {
        monkeys[index].TrueIndex = int.Parse(line.Replace("    If true: throw to monkey ", ""));
    }
    else if (line.StartsWith("    If false: throw to monkey "))
    {
        monkeys[index].FalseIndex = int.Parse(line.Replace("    If false: throw to monkey ", ""));
    }
    else if (line.StartsWith("  Operation: new = old "))
    {
        if (line == "  Operation: new = old * old")
        {
            monkeys[index].Operation = old => old * old;
        }
        else
        {
            var end = line.Replace("  Operation: new = old ", "");
            var value = int.Parse(end.Substring(2));
            if (end[0] == '*')
                monkeys[index].Operation = old => old * value;
            else if (end[0] == '+')
                monkeys[index].Operation = old => old + value;
            else
                throw new Exception();
        }
    }
}

// 20
for (int i = 0; i < 1_000; i++)
{
    foreach (var monkey in monkeys)
    {
        Process(monkey);
    }
}
monkeys.OrderByDescending(x => x.Total).Take(2).ToList().ForEach(x => Console.WriteLine(x.Total));
Console.WriteLine(monkeys.OrderByDescending(x => x.Total).Take(2).Aggregate(1L, (x, y) => x * y.Total));
// 1100331704 too low
// 18280200888 too high

// test 2713310158 theirs
// test 2637600014 mine

void Process(Monkey monkey)
{
    foreach (var item in monkey.Items)
    {
        var level = monkey.Operation(item);
        // level /= 3; // part 1
        if (level % monkey.Test == 0)
            monkeys[monkey.TrueIndex].Items.Add(level);
        else
            monkeys[monkey.FalseIndex].Items.Add(level);
    }
    monkey.Total += monkey.Items.Count;
    monkey.Items.Clear();
}

class Monkey
{
    public List<long> Items { get; set; } = new List<long>();
    public Func<long, long> Operation { get; set; }
    public long Test { get; set; }
    public int TrueIndex { get; set; }
    public int FalseIndex { get; set; }
    public long Total { get; set; }
    public override string ToString()
    {
        return $"{Items.Count} {Test} {TrueIndex} {FalseIndex}";
    }
}