var lines = File.ReadAllLines("input");
var original = new int[lines.Length];
var size = original.Length;
Elem? root = null;
Elem? previous = null;
for (int i = 0; i < lines.Length; i++)
{
    original[i] = int.Parse(lines[i]);
    var cursor = new Elem { Index = i, Value = original[i] };
    if (root == null) root = cursor;
    if (previous != null) previous.Right = cursor;
    previous = cursor;
}
previous.Right = root;

for (int i = 0; i < original.Length; i++)
{
    Move1(i, original[i]);
}

var zero = FindByValue(0);
var x1 = FindNext(zero, 1000);
var x2 = FindNext(x1, 1000);
var x3 = FindNext(x2, 1000);
Console.WriteLine(x1.Value + x2.Value + x3.Value);

void Move1(int index, int positions)
{
    if (positions % size == 0) return;
    var elem = FindByIndex(index);
    Move2(elem, positions);
}
void Move2(Elem elem, int positions)
{
    int positions2;

    if (positions > 0)
    {
        positions2 = positions % size;
    }
    else
    {
        positions2 = --positions % size + size;
        //positions2 = (-positions+1) % size;
    }

    var elem2 = FindNext(elem, positions2);
    Move3(elem, elem2);
}
void Move3(Elem elem1, Elem elem2)
{
    var elem1Before = FindByRight(elem1);
    var elem1After = elem1.Right;
    var elem2Before = FindByRight(elem2);
    var elem2After = elem2.Right;

    if (elem1 == elem2)
    {
        return;
    }

    if (elem1.Right == elem2)
    {
        // 2 elem1A->elem1->elem2->elem2B
        elem1Before.Right = elem2;
        elem2.Right = elem1;
        elem1.Right = elem2After;
        return;
    }

    if (elem2.Right == elem1)
    {
        // 3 elem2A->elem2->elem1->elem1B
        elem2.Right = elem1After;
        elem1.Right = elem2;
        elem2Before.Right = elem1;
        return;
    }

    // 1 elem1A->elem1->elem1B ... ->elem2A->elem2->elem2B
    elem1Before.Right = elem1After;
    elem2.Right = elem1;
    elem1.Right = elem2After;
}
Elem FindNext(Elem elem, int positions)
{
    var cursor = elem;
    while (positions > 0)
    {
        cursor = cursor.Right;
        positions--;
    }
    return cursor;
}
Elem FindByIndex(int index)
{
    var cursor = root;
    while (true)
    {
        if (cursor.Index == index) return cursor;
        cursor = cursor.Right;
    }
}
Elem FindByRight(Elem elem)
{
    var cursor = root;
    while (true)
    {
        if (cursor.Right == elem) return cursor;
        cursor = cursor.Right;
    }
}
Elem FindByValue(int value)
{
    var cursor = root;
    while (true)
    {
        if (cursor.Value == value) return cursor;
        cursor = cursor.Right;
    }
}
class Elem
{
    public int Index;
    public int Value;
    public Elem Right;
    public override string ToString()
    {
        return Value.ToString();
    }
}

// 14526 
// 9173
// 2487 too low