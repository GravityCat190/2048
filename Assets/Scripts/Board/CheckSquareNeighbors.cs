using System.Collections.Generic;
using UnityEngine;

public class CheckSquareNeighbors : MonoBehaviour
{
    [SerializeField]
    private Map Map = default;

    private List<Square> squares;

    private const int mapSize = Map.mapSize;

    private Square currentSquare;
    private int row;
    private int column;

    private void Awake()
    {
        squares = Map.Squares;
    }

    public bool IsPossibleToMoveOnNeighbor(Square checkedSquare)
    {
        currentSquare = checkedSquare;
        row = currentSquare.Row;
        column = currentSquare.Column;

        Square[] neighbors;
        neighbors = FindNeighbors();
        foreach (Square neighbor in neighbors)
        {
            if (neighbor != null && CheckNeighbor(neighbor))
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckNeighbor(Square neighbor)
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
        if ((row + 1) < mapSize)
        {
            int wantedIndex = (row + 1) * mapSize + column;
            return squares[wantedIndex];
        }
        return null;
    }

    private Square FindNeighborAbove()
    {
        if ((row - 1) > 0)
        {
            int wantedIndex = (row - 1) * mapSize + column;
            return squares[wantedIndex];
        }
        return null;
    }

    private Square FindNeighborRight()
    {
        if ((column + 1) < mapSize)
        {
            int wantedIndex = row * mapSize + (column + 1);
            return squares[wantedIndex];
        }
        return null;
    }
    private Square FindNeighborLeft()
    {
        if ((column - 1) > 0)
        {
            int wantedIndex = row * mapSize + (column - 1);
            return squares[wantedIndex];
        }
        return null;
    }
}
