var lines = await File.ReadAllLinesAsync("input");

const int total = 70_000_000;
const int needed = 30_000_000;

var dir = new Dir { Name = "/" };
var root = dir;

foreach (var line in lines.Skip(1))
{
    if (line == "$ ls")
    {
    }
    else if (line.StartsWith("dir "))
    {
        dir.Dirs.Add(new Dir { Name = line.Replace("dir ", ""), Parent = dir });
    }
    else if (line == "$ cd ..")
    {
        dir = dir.Parent;
    }
    else if (line.StartsWith("$ cd "))
    {
        dir = dir.Dirs.First(x => x.Name == line.Replace("$ cd ", ""));
    }
    else
    {
        dir.FilesSize += int.Parse(line.Split(" ")[0]);
    }
}

SetTotalSizes(root);
Console.WriteLine("1: " + TotalSizesSumBelow(root, 100_000));

var used = root.TotalSize;
var free = total - used;
var neededMore = needed - free;
int result = int.MaxValue;
FindSmallestBiggerThan(root, neededMore, ref result);
Console.WriteLine("2: " + result);

void FindSmallestBiggerThan(Dir dir, int neededMore, ref int current)
{
    var dirSize = dir.TotalSize;
    if (dirSize >= neededMore && dirSize < current)
        current = dirSize;
    foreach (var d in dir.Dirs)
        FindSmallestBiggerThan(d, neededMore, ref current);
}
void SetTotalSizes(Dir dir)
{
    dir.Dirs.ToList().ForEach(SetTotalSizes);
    dir.TotalSize = dir.FilesSize + dir.Dirs.Sum(x => x.TotalSize);
}
int TotalSizesSumBelow(Dir dir, int threshold)
{
    var x = dir.TotalSize > threshold ? 0 : dir.TotalSize;
    var xs = dir.Dirs.Sum(x => TotalSizesSumBelow(x, threshold));
    return x + xs;
}
class Dir
{
    public string Name { get; set; }
    public int FilesSize { get; set; }
    public int TotalSize { get; set; }
    public Dir Parent { get; set; }
    public List<Dir> Dirs = new List<Dir>();
}