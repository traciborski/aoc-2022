var line = await File.ReadAllTextAsync("input");
var size = 14;
for (int i = size; i < line.Length; i++)
    if (line[(i - size)..i].Distinct().Count() == size)
        Console.WriteLine(i);