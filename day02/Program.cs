internal class Program
{
    private static async Task Main()
    {
        var lines = await File.ReadAllLinesAsync("input");
        //var sum1 = 0;
        var sum2 = 0;
        foreach (var line in lines)
        {
            var them = Figure2(line[0]);
            var score = Result(line[2]);
            var me = ShapeFromScore(them, score);
            //sum1 += Score(Figure2(line[0]), Figure2(line[2]));
            sum2 += score + FigureValue(me);
        }
        //Console.WriteLine(sum1);
        Console.WriteLine(sum2);

        Figure Figure2(char ch)
        {
            switch (ch)
            {
                case 'A':
                case 'X':
                    return Figure.Rock;
                case 'B':
                case 'Y':
                    return Figure.Paper;
                case 'C':
                case 'Z':
                    return Figure.Scissor;
                default:
                    throw new Exception();
            }
        }
    }

    private static Figure ShapeFromScore(Figure them, int score)
    {
        if (score == 3) return them;

        if (score == 0)
        {
            if (them == Figure.Rock) return Figure.Scissor;
            if (them == Figure.Scissor) return Figure.Paper;
            if (them == Figure.Paper) return Figure.Rock;
        }

        if (score == 6)
        {
            if (them == Figure.Rock) return Figure.Paper;
            if (them == Figure.Scissor) return Figure.Rock;
            if (them == Figure.Paper) return Figure.Scissor;
        }

        throw new Exception();
    }

    private static int Result(char v)
    {
        return v switch
        {
            'X' => 0,
            'Y' => 3,
            'Z' => 6,
        };
    }

    private static int FigureValue(Figure me)
    {
        return me switch
        {
            Figure.Rock => 1,
            Figure.Paper => 2,
            Figure.Scissor => 3,
        };
    }

    private static int Score(Figure them, Figure me)
    {
        if (them == me) return 3;

        if (them == Figure.Rock)
        {
            if (me == Figure.Paper) return 6;
            if (me == Figure.Scissor) return 0;
        }

        if (them == Figure.Scissor)
        {
            if (me == Figure.Rock) return 6;
            if (me == Figure.Paper) return 0;
        }

        if (them == Figure.Paper)
        {
            if (me == Figure.Scissor) return 6;
            if (me == Figure.Rock) return 0;
        }

        throw new Exception();
    }
    enum Figure
    {
        Rock,
        Paper,
        Scissor,
    }
}

