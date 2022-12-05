var lines = await File.ReadAllLinesAsync("input");
var sum = 0;
var index = 0;
var dicts = new HashSet<char>[3];
foreach (var line in lines)
{
    var dict = new HashSet<char>();
    dicts[index] = dict;

    foreach (var ch in line)
    {
        dict.Add(ch);
    }

    if (index == 2)
    {
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            if (dicts[0].Contains(ch) && dicts[1].Contains(ch) && dicts[2].Contains(ch))
            {
                sum += Score(ch);
                break;
            }
        }
        for (char ch = 'A'; ch <= 'Z'; ch++)
        {
            if (dicts[0].Contains(ch) && dicts[1].Contains(ch) && dicts[2].Contains(ch))
            {
                sum += Score(ch);
                break;
            }
        }
    }

    index = ++index % 3;
}

int Score(char ch)
{
    if (ch < 'a')
    {
        return (byte)ch - 65 + 27;
    }
    return (byte)ch - 97 + 1;
}

//var c = 'A';
//Console.WriteLine($"{c} {(byte)c} {Score(c)}");
//c = 'a';
//Console.WriteLine($"{c} {(byte)c} {Score(c)}");
Console.WriteLine(sum);