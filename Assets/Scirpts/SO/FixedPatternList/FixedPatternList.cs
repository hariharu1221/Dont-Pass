using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FixedPatternList", menuName = "SO/FixedPatternList", order = 1)]
public class FixedPatternList : ScriptableObject //
{
    public List<string> list;

    public FixedPattern Read(int index)
    {
        return new FixedPattern(CSVReader.Read(list[index]));
    }

    public List<FixedPattern> ReadAll()
    {
        List<FixedPattern> list = new List<FixedPattern>();
        foreach (string i in this.list)
            list.Add(new FixedPattern(CSVReader.Read(i)));
        return list;
    }
}