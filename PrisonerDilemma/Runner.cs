namespace PrisonerDilemma;

public static class Runner
{
    private static Dictionary<Tuple<bool, bool>, Tuple<int, int>> koeff = new();

    static Runner()
    {
        koeff[new Tuple<bool, bool>(true, true)] = new Tuple<int, int>(3, 3);
        koeff[new Tuple<bool, bool>(false, true)] = new Tuple<int, int>(5, 0);
        koeff[new Tuple<bool, bool>(true, false)] = new Tuple<int, int>(0, 5);
        koeff[new Tuple<bool, bool>(false, false)] = new Tuple<int, int>(1, 1);
    }

    public static Tuple<int, int> Run(IPrisoner firstPrisoner, IPrisoner secondPrisoner)
    {
        var rnd = new Random();
        var step = rnd.Next(190, 210);
        var results = new List<Tuple<bool, bool>>();
        for (var i = 0; i < step; i++)
        {
            var result = (firstPrisoner.GetSolutionForNextStep(results.Select(x => x.Item2).ToArray()),
                secondPrisoner.GetSolutionForNextStep(results.Select(x => x.Item1).ToArray()));
            results.Add(new Tuple<bool, bool>(result.Item1, result.Item2));
        }

        var firstSum = results.Select(x => koeff[x].Item1)
            .ToArray();
        var secondSum = results.Select(x => koeff[x].Item2)
            .ToArray();
        return new Tuple<int, int>(firstSum.Sum(),
            secondSum.Sum());
    }
}