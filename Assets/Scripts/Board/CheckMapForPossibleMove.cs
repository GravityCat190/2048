using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMapForPossibleMove : MonoBehaviour
{
    [SerializeField]
    private Map Map = default;
    [SerializeField]
    private CheckSquareNeighbors CheckSquareNeighbors = default;

    public bool IsPossible()
    {
        foreach (Square square in Map.Squares)
        {
            if (CheckSquareNeighbors.IsPossibleToMoveOnNeighbor(square))
            {
                return true;
            }
        }

        return false;
    }
}
