using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pattern
{
    private RangePoint rangeCool;
    public RangePoint RangeCool { get { return rangeCool; } }

    private RangePoint rangeScore;
    public RangePoint RangeScore { get { return rangeScore; } }

    private RangePoint rangeTempo;
    public RangePoint RangeTempo { get { return rangeTempo; } }

    public Pattern(RangePoint cool, RangePoint score, RangePoint tempo)
    {
        rangeCool = cool;
        rangeScore = score;
        rangeTempo = tempo;
    }
}