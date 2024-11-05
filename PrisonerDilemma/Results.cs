using System.Data;

namespace PrisonerDilemma;

public class Results
{
    private Dictionary<Type, Dictionary<Type, Tuple<int, int>>> _dataTable = [];

    public Tuple<int, int> this[(Type, Type) valueTuple]
    {
        get
        {
            var (column, row) = valueTuple;
            return _dataTable[column][row];
        }
        set
        {
            var (column, row) = valueTuple;
            if (!_dataTable.ContainsKey(column))
                _dataTable[column] = new Dictionary<Type, Tuple<int, int>>();
            if (!_dataTable.ContainsKey(row))
                _dataTable[row] = new Dictionary<Type, Tuple<int, int>>();
            _dataTable[column][row] = value;
            _dataTable[row][column] = new Tuple<int, int>(value.Item2, value.Item1);
        }
    }
    
    public Dictionary<Type, Tuple<int, int>> this[Type type] => _dataTable[type];
}