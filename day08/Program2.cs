var lines = await File.ReadAllLinesAsync("input");

var size = lines.Length;

var heights = new char[size, size];
var v_t = new int[size, size]; // visibility from top
var v_b = new int[size, size]; // visibility from bottom
var v_l = new int[size, size]; // visibility from left 
var v_r = new int[size, size]; // visibility from right
var v = new int[size, size]; // visibility 

// heights
for (int y = 0; y < size; y++)
    for (int x = 0; x < size; x++)
        heights[y, x] = lines[y][x];

// exterior visibility
for (int i = 0; i < size; i++)
{
    v_t[0, i] = 0;
    v_b[size - 1, i] = 0;
    v_l[i, 0] = 0;
    v_r[i, size - 1] = 0;
}

// interior visibility
for (int y = 0; y < size; y++)
{
    for (int x = 0; x < size; x++)
    {
        if (y > 0) v_t[y, x] = Visibility((0, x), (y, x));
        if (y < size - 1) v_b[y, x] = Visibility((size - 1, x), (y, x));
        if (x > 0) v_l[y, x] = Visibility((y, 0), (y, x));
        if (x < size - 1) v_r[y, x] = Visibility((y, size - 1), (y, x));
    }
}

// visibility
for (int y = 0; y < size; y++)
    for (int x = 0; x < size; x++)
        v[y, x] = v_b[y, x] * v_t[y, x] * v_r[y, x] * v_l[y, x];

// maximum
var max = 0;
for (int y = 0; y < size; y++)
    for (int x = 0; x < size; x++)
        if (v[y, x] > max) max = v[y, x];
Console.WriteLine("2: " + max);

int Visibility((int y, int x) to, (int y, int x) from)
{
    var increment_y = Increment(from.y, to.y);
    var increment_x = Increment(from.x, to.x);
    var y = from.y;
    var x = from.x;
    var sum = 0;
    while (y != to.y || x != to.x)
    {
        y += increment_y;
        x += increment_x;
        sum++;
        if (heights[y, x] >= heights[from.y, from.x])
            break;
    }
    return sum;
}

int Increment(int x1, int x2)
{
    return x2.CompareTo(x1);
}
