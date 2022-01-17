using System;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField]
    private IntGameEvent onSquareMerged;
    public void Move(Square[] currentArray, int squareIndex, int moveDistance)
    {
        if (moveDistance > 0)
        {
            Square startSquare = currentArray[squareIndex];
            Square destinationSquare = currentArray[squareIndex + moveDistance];

            bool isDestinationSquareNotEmpty = Convert.ToBoolean(destinationSquare.Points);
            ChangeDestinationSquare(startSquare, destinationSquare);
            ChangeStartSquare(startSquare);

            if (isDestinationSquareNotEmpty)
            {
                onSquareMerged?.Raise(destinationSquare.Points);
            }
        }
    }

    private void ChangeDestinationSquare(Square startSquare, Square destinationSquare)
    {
        int startSquarePoints = startSquare.Points;
        int destinationSquarePoints = destinationSquare.Points;
        destinationSquare.Points = startSquarePoints + destinationSquarePoints;
    }

    private void ChangeStartSquare(Square startSquare)
    {
        startSquare.Points = 0;
    }
}