// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Reflection;
using PrisonerDilemma;

var prisoners = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IPrisoner)))
    .ToArray();
var couples = new List<(Type, Type)>();
var results = new Results();
for (var i = 0; i < prisoners.Length - 1; i++)
{
    for (var j = i; j < prisoners.Length; j++)
    {
        couples.Add((prisoners[i], prisoners[j]));
    }
}

foreach (var couple in couples)
{
    var firstPrisoner = Activator.CreateInstance(couple.Item1) as IPrisoner;
    var secondPrisoner = Activator.CreateInstance(couple.Item2) as IPrisoner;
    if(firstPrisoner == null || secondPrisoner == null)
        throw new ApplicationException("Don't know how to create prisoner");
    var result = Runner.Run(firstPrisoner, secondPrisoner);
    results[couple] = result;
}

foreach (var prisoner in prisoners)
{
    var sum = results[prisoner].Select(x => x.Value.Item1).Sum();
    Console.WriteLine($"{prisoner.Name} :  {sum}");
}
