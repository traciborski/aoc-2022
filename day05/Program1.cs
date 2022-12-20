//var lines = await File.ReadAllLinesAsync("input");

//var stacks = new Stack<char>[9];
//for (var j = 0; j < 9; j++)
//    stacks[j] = new Stack<char>();

//int cursor;
//for (cursor = 0; cursor < lines.Length; cursor++)
//{
//    var line = lines[cursor];
    
//    if (line == "") break;

//    for (int j = 0; j < line.Length; j++)
//    {
//        char c = line[j];

//        if (c is ' ' or '[' or ']')
//            continue;

//        if (c == '1')
//            break;

//        var stack = j / 4;
//        stacks[stack].Push(c);
//    }
//}

//cursor++;

//for (int j = 0; j < stacks.Length; j++)
//{
//    stacks[j] = new Stack<char>(stacks[j].AsEnumerable());
//}

//for (; cursor < lines.Length; cursor++)
//{
//    var line = lines[cursor];
//    var words = line.Split(' ');
//    var count = int.Parse(words[1]);
//    var from = int.Parse(words[3]) - 1;
//    var to = int.Parse(words[5]) - 1;

//    for (int j = 0; j < count; j++)
//    {
//        var c = stacks[from].Pop();
//        stacks[to].Push(c);
//    }
//}

//foreach (var stack in stacks)
//{
//    Console.Write($"{stack.Peek()}");
//}