//var lines = await File.ReadAllLinesAsync("input");
//var h = (0, 0);
//var t = (0, 0);
//var visited = new HashSet<(int, int)> { t };
//foreach (var line in lines)
//{
//    var words = line.Split(' ');
//    var direction = words[0];
//    var steps = int.Parse(words[1]);

//    while (steps > 0)
//    {
//        h = Move(direction, h);
//        steps--;

//        if (!AreClose(h, t))
//        {
//            t = MoveToward(t, h);
//            visited.Add(t);
//        }
//    }
//}

//Console.WriteLine(visited.Count);

//(int, int) MoveToward((int x, int y) t, (int x, int y) h)
//{
//    return (t.x - t.x.CompareTo(h.x), t.y - t.y.CompareTo(h.y));
//}

//(int, int) Move(string direction, (int x, int y) h)
//{
//    if (direction == "D") return (h.x, h.y + 1);
//    if (direction == "U") return (h.x, h.y - 1);
//    if (direction == "L") return (h.x - 1, h.y);
//    if (direction == "R") return (h.x + 1, h.y);
//    throw new NotImplementedException();
//}

//bool AreClose((int x, int y) h, (int x, int y) t)
//{
//    return Math.Abs(h.x - t.x) <= 1 && Math.Abs(h.y - t.y) <= 1;
//}