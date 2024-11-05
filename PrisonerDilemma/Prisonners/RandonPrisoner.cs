namespace PrisonerDilemma.Prisonners;

public class RandomPrisoner: IPrisoner
{
    public bool GetSolutionForNextStep(bool[] previousDecisions)
    {
        return new Random().Next(0,2) == 0 ;
    }
}