var lines = await File.ReadAllLinesAsync("input");
var max = new List<int> { 0, 0, 0};
var current = 0;
foreach (var line in lines)
{
    var min_max = max.Min();

    if (line == "")
    {
        if (current > min_max)
        {
            max.Add(current);
            max = max.Order().Skip(1).ToList();
        }

        current = 0;
    }
    else
    {
        current += int.Parse(line);
    }
}
Console.WriteLine(max[2]);
Console.WriteLine(max.Sum());