namespace PrisonerDilemma;

public interface IPrisoner
{
    public bool GetSolutionForNextStep(bool[] previousDecisions);
}