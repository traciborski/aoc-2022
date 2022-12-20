//var lines = await File.ReadAllLinesAsync("input");
//var sum = 0;
//foreach (var line in lines)
//{
//    var pair = line.Split(',');
//    var first = pair[0].Split('-').Select(int.Parse).ToArray();
//    var second = pair[1].Split('-').Select(int.Parse).ToArray();
//    var f = (first[0], first[1] + 1);
//    var s = (second[0], second[1] + 1);
//    if (Contains(f, s) || Contains(s, f))
//    {
//        sum++;
//    }
//}

//bool Contains((int Start, int End) x, (int Start, int End) y)
//{
//    return x.Start <= y.Start && x.End >= y.End;
//}

//Console.WriteLine(sum);