var lines = await File.ReadAllLinesAsync("input");
var heightmap = new char[lines.Length, lines[0].Length];
var S = new HashSet<(int, int)>();
var E = new List<(int, int)>();
var S_Candidates = new HashSet<(int, int)>();
for (int y = 0; y < lines.Length; y++)
{
	var line = lines[y];
	for (int x = 0; x < line.Length; x++)
	{
		var height = line[x];
		if (height == 'S')
		{
			S.Add((y, x));
			S_Candidates.Add((y, x));
			heightmap[y, x] = 'a';
		}
		else if (height == 'E')
		{
			E.Add((y, x));
			heightmap[y, x] = 'z';
		}
		else
		{
			if (height == 'a') S_Candidates.Add((y, x));
			heightmap[y, x] = height;
		}
	}
}

var min = int.MaxValue;
foreach (var s in S_Candidates)
{
	S = new HashSet<(int, int)> { s };
	var steps = CountSteps();
	if (steps < int.MaxValue)
		Console.WriteLine(steps);
	if (steps < min) min = steps;
}
Console.WriteLine(min);

int CountSteps()
{
	var steps = 0;
	while (!Overlap(S, E))
	{
		if (!FindNext())
			return int.MaxValue;
		steps += 1;
	}
	return steps;
}

bool FindNext()
{
	var result = false;
	foreach (var from in S.ToArray())
	{
		result |= TryMove(from, -1, 0);
		result |= TryMove(from, 1, 0);
		result |= TryMove(from, 0, -1);
		result |= TryMove(from, 0, 1);
	}
	return result;
}

bool TryMove((int y, int x) from, int dy, int dx)
{
	var to_y = from.y + dy;
	var to_x = from.x + dx;
	if (to_y < 0) return false;
	if (to_x < 0) return false;
	if (to_y >= lines.Length) return false;
	if (to_x >= lines[0].Length) return false;
	var from_height = heightmap[from.y, from.x];
	var to_height = heightmap[to_y, to_x];
	if (to_height - from_height <= 1)
		return S.Add((to_y, to_x));
	return false;
}

bool Overlap(IEnumerable<(int y, int x)> S, IEnumerable<(int y, int x)> E)
{
	foreach (var s in S)
		foreach (var e in E)
			if (s == e)
				return true;
	return false;
}