var lines = File.ReadAllLines("input");

var sum = 0L;

// quintet to decimal
foreach (var line in lines)
{
    var factor = 1L;
    foreach (var c in line.Reverse())
    {
        var d = c switch
        {
            '-' => -1,
            '=' => -2,
            '0' => 0,
            '1' => 1,
            '2' => 2,
        };
        sum += d * factor;
        factor *= 5;
    }
}

// decimal to quintet
var output = "";
while (sum > 0)
{
    var r = sum % 5;
    sum /= 5;
    if (r == 0)
    {
        output = "0" + output;
    }
    else if (r == 1)
    {
        output = "1" + output;
    }
    else if (r == 2)
    {
        output = "2" + output;
    }
    if (r == 3)
    {
        output = "=" + output;
        sum += 1;
    }
    else if (r == 4)
    {
        output = "-" + output;
        sum += 1;
    }
}
Console.WriteLine(output);