var line = await File.ReadAllTextAsync("input");

var x = line[0];

var size = 14;

var last_four = Enumerable.Repeat(x, size).ToArray();

for (int i = 0; i < line.Length; i++)
{
    char ch = line[i];
    if (last_four.Distinct().Count() == last_four.Length) // unique ?
    {
        Console.WriteLine(i);
        return;
    }
    // swap
    for (int j = 0; j < size - 1; j++)
    {
        last_four[j] = last_four[j+1];
    }
    last_four[size-1] = ch;
}