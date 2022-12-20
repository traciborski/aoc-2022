var lines = File.ReadAllLines("input0");
var time = 24;

Result Measure(Robot[] specs, Robot[] robots, Product[] products, int time)
{
    if (time == 0)
        //return result.Count(x=>x.Resource == Resource.obsidian);
        return new Result(robots, products);

    // produce resources

    // produce robots
    var toConsider = new List<Robot>();
    foreach (Robot robot in specs)
    {
        if (robot.CanProduce(products))
            toConsider.Add(robot);
    }

    //toConsider.perm

    return null;
}

void permute(String str, int l, int r)
{
    if (l == r)
        Console.WriteLine(str);
    else
    {
        for (int i = l; i <= r; i++)
        {
            str = swap(str, l, i);
            permute(str, l + 1, r);
            str = swap(str, l, i);
        }
    }
}

String swap(String a, int i, int j)
{
    char temp;
    char[] charArray = a.ToCharArray();
    temp = charArray[i];
    charArray[i] = charArray[j];
    charArray[j] = temp;
    string s = new string(charArray);
    return s;
}

//record Blueprint(params Robot[] robots);
record Robot(Product Produces, Product[] Costs)
{
    public bool CanProduce(Product[] costs)
    {
        return false;
    }
}
record Product(Resource Resource, int Amount);
record Result(Robot[] Robots, Product[] Products);
enum Resource { ore, clay, obsidian, geode };
