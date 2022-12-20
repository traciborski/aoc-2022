var lines = await File.ReadAllLinesAsync("input");

var stacks = new Stack<char>[9];
for (var i = 0; i < 9; i++)
    stacks[i] = new Stack<char>();

int cursor;
for (cursor = 0; cursor < lines.Length; cursor++)
{
    var line = lines[cursor];

    if (line == "") break;

    for (int j = 0; j < line.Length; j++)
    {
        char c = line[j];

        if (c is ' ' or '[' or ']')
            continue;

        if (c == '1')
            break;

        var stack = j / 4;
        stacks[stack].Push(c);
    }
}

cursor++;

for (int i = 0; i < stacks.Length; i++)
{
    stacks[i] = new Stack<char>(stacks[i].AsEnumerable());
}

for (; cursor < lines.Length; cursor++)
{
    var line = lines[cursor];
    var words = line.Split(' ');
    var count = int.Parse(words[1]);
    var from = int.Parse(words[3]) - 1;
    var to = int.Parse(words[5]) - 1;

    var batch = new List<char>();
    while (count > 0)
    {
        var c = stacks[from].Pop();
        batch.Add(c);
        count--;
    }
    batch.Reverse();
    foreach (char c in batch)
        stacks[to].Push(c);
}

foreach (var stack in stacks)
{
    Console.Write($"{stack.Peek()}");
}