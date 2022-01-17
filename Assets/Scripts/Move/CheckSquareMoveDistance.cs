using System;
using UnityEngine;

public class CheckSquareMoveDistance : MonoBehaviour
{
    public int CalculateMoveDistance(Square[] mapFragment, int squareIndex)
    {
        Square currentSquare = mapFragment[squareIndex];
        int currentSquarePoints = currentSquare.Points;

        int moveDistance = 0;
        int mapSize = mapFragment.Length;

        for (int i = squareIndex + 1; i < mapSize; i++)
        {
            Square nextSquare = mapFragment[i];
            bool makeNextMove = PossibleToMoveOnNextSquare(nextSquare, currentSquarePoints);
            if (makeNextMove)
            {
                ++moveDistance;
            }
            else
            {
                return moveDistance;
            }
        }
        return moveDistance;
    }

    private bool PossibleToMoveOnNextSquare(Square SquareToCheck, int currentSquarePoints)
    {
        int checkedSquarePoints = SquareToCheck.Points;

        bool canMergeWithNextSquare = checkedSquarePoints == currentSquarePoints;
        bool isNextSquareNotEmpty = Convert.ToBoolean(checkedSquarePoints);

        if (canMergeWithNextSquare || !isNextSquareNotEmpty)
        {
            return true;
        }
        return false;
    }
}
