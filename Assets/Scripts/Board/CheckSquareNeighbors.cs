using System.Collections.Generic;
using UnityEngine;

public class CheckSquareNeighbors : MonoBehaviour
{
    [SerializeField]
    private Map map = default;

    private List<Square> squares;
    private Square currentSquare;
    private int row;
    private int column;

    private void Awake()
    {
        squares = map.Squares;
    }

    public bool IsPossibleToMoveOnNeighbors(Square checkedSquare)
    {
        currentSquare = checkedSquare;
        row = currentSquare.Row;
        column = currentSquare.Column;

        Square[] neighbors;
        neighbors = FindNeighbors();
        foreach (Square neighbor in neighbors)
        {
            if (neighbor != null && IsPossibleToMerge(neighbor))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPossibleToMerge(Square neighbor)
    {
        if (currentSquare.Points == neighbor.Points)
        {
            return true;
        }
        return false;
    }

    private Square[] FindNeighbors()
    {
        row = currentSquare.Row;
        column = currentSquare.Column;

        return new Square[4] { FindNeighborBelow(), FindNeighborAbove(), FindNeighborRight(), FindNeighborLeft() };
    }

    private Square FindNeighborBelow()
    {
        if ((row + 1) < Map.MapSize)
        {
            int wantedIndex = (row + 1) * Map.MapSize + column;
            return squares[wantedIndex];
        }
        return null;
    }

    private Square FindNeighborAbove()
    {
        if ((row - 1) > 0)
        {
            int wantedIndex = (row - 1) * Map.MapSize + column;
            return squares[wantedIndex];
        }
        return null;
    }

    private Square FindNeighborRight()
    {
        if ((column + 1) < Map.MapSize)
        {
            int wantedIndex = row * Map.MapSize + (column + 1);
            return squares[wantedIndex];
        }
        return null;
    }
    private Square FindNeighborLeft()
    {
        if ((column - 1) > 0)
        {
            int wantedIndex = row * Map.MapSize + (column - 1);
            return squares[wantedIndex];
        }
        return null;
    }
}
