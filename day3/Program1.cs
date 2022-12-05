//var lines = await File.ReadAllLinesAsync("input");
//var sum = 0;
//foreach (var line in lines)
//{
//    var dict = new HashSet<char>();

//    foreach (var ch in line.Take(line.Length / 2))
//    {
//        dict.Add(ch);
//    }

//    foreach (var ch in line.Skip(line.Length / 2))
//    {
//        if (dict.Contains(ch))
//        {
//            sum += Score(ch);
//            break;
//        }
//    }
//}

//int Score(char ch)
//{
//    if (ch < 'a')
//    {
//        return (byte)ch - 65 + 27;
//    }
//    return (byte)ch - 97 + 1;
//}

////var c = 'A';
////Console.WriteLine($"{c} {(byte)c} {Score(c)}");
////c = 'a';
////Console.WriteLine($"{c} {(byte)c} {Score(c)}");
//Console.WriteLine(sum);