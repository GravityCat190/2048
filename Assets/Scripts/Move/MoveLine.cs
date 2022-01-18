using System;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    [SerializeField]
    private CheckSquareMoveDistance checkSquareMoveDistance = default;
    [SerializeField]
    private MoveSquare moveSquare = default;

    private const int Offset = 2; //mapsize - 1 (because index is from 0) and again - 1 to skip the first square (because it never move)

    public int Move(Square[] currentArray)
    {
        int mapSize = currentArray.Length;
        int moveDistance;
        int distanceMoveSum = 0;
        for (int squareIndex = mapSize - Offset; squareIndex >= 0; squareIndex--)
        {
            if (!currentArray[squareIndex].IsEmpty)
            {
                moveDistance = checkSquareMoveDistance.CalculateMoveDistance(currentArray, squareIndex);
                distanceMoveSum += moveDistance;
                moveSquare.Move(currentArray, squareIndex, moveDistance);
            }
        }
        return distanceMoveSum;
    }
}
