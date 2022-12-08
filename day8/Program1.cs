//var lines = await File.ReadAllLinesAsync("input");

//var size = lines.Length;

//var heights = new char[size, size];
//var v_t = new bool[size, size]; // visibility from top
//var v_b = new bool[size, size]; // visibility from bottom
//var v_l = new bool[size, size]; // visibility from left 
//var v_r = new bool[size, size]; // visibility from right
//var v = new bool[size, size]; // visibility 

//// heights
//for (int y = 0; y < size; y++)
//    for (int x = 0; x < size; x++)
//        heights[y, x] = lines[y][x];

//// exterior visibility
//for (int i = 0; i < size; i++)
//{
//    v_t[0, i] = true;
//    v_b[size - 1, i] = true;
//    v_l[i, 0] = true;
//    v_r[i, size - 1] = true;
//}

//// interior visibility
//for (int y = 0; y < size; y++)
//{
//    for (int x = 0; x < size; x++)
//    {
//        if (y > 0) v_t[y, x] = AllSmaller((0, x), (y, x));
//        if (y < size - 1) v_b[y, x] = AllSmaller((size - 1, x), (y, x));
//        if (x > 0) v_l[y, x] = AllSmaller((y, 0), (y, x));
//        if (x < size - 1) v_r[y, x] = AllSmaller((y, size - 1), (y, x));
//    }
//}

//// visibility
//for (int y = 0; y < size; y++)
//    for (int x = 0; x < size; x++)
//        v[y, x] = v_b[y, x] || v_t[y, x] || v_r[y, x] || v_l[y, x];

//var sum = 0;
//for (int y = 0; y < size; y++)
//    for (int x = 0; x < size; x++)
//        if (v[y, x]) sum++;

//Console.WriteLine("1: " + sum);

//bool AllSmaller((int y, int x) from, (int y, int x) to)
//{
//    var increment_y = Increment(from.y, to.y);
//    var increment_x = Increment(from.x, to.x);

//    var y = from.y;
//    var x = from.x;
//    while (y != to.y || x != to.x)
//    {
//        if (heights[y, x] >= heights[to.y, to.x])
//            return false;

//        y += increment_y;
//        x += increment_x;
//    }
//    return true;
//}

//int Increment(int x1, int x2)
//{
//    return x2.CompareTo(x1);
//}
