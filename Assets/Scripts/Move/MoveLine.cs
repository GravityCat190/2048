using System;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    [SerializeField]
    private CheckSquareMoveDistance CheckSquareMoveDistance = default;
    [SerializeField]
    private MoveSquare MoveSquare = default;

    private const int offset = 2; //mapsize - 1 (because index is from 0) and again - 1 to skip the first square (because it never move)

    public int Move(Square[] currentArray)
    {
        int mapSize = currentArray.Length;
        int moveDistance;
        int distanceMoveSum = 0;
        for (int squareIndex = mapSize - offset; squareIndex >= 0; squareIndex--)
        {
            bool isCurrentSquareNotEmpty = Convert.ToBoolean(currentArray[squareIndex].Points);
            if (isCurrentSquareNotEmpty)
            {
                moveDistance = CheckSquareMoveDistance.CalculateMoveDistance(currentArray, squareIndex);
                distanceMoveSum += moveDistance;
                MoveSquare.Move(currentArray, squareIndex, moveDistance);
            }
        }
        return distanceMoveSum;
    }
}
