using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FindEmptySquare : MonoBehaviour
{
    
    [SerializeField]
    private Map Map;

    private int squaresAmount = Map.MapSize * Map.MapSize;
    private List<Square> squares;

    private void Awake()
    {
        squares = Map.Squares;
    }

    public Square GetRandomSquare()
    {
        Square square = TryGetRandomSquare();
        if (square == null)
        {
            square = GetFirstSquare();
        }

        return square;
    }

    private Square TryGetRandomSquare()
    {
        int randomIndex = Random.Range(0, squaresAmount);
        for (int i = randomIndex; i < squaresAmount; i++)
        {
            if (squares[i].IsEmpty)
            {
                return squares[i];
            }
        }
        return null;
    }

    public Square GetFirstSquare()
    {
        for (int i = 0; i < squaresAmount; i++)
        {
            if (squares[i].IsEmpty)
            {
                return squares[i];
            }
        }
        return null;
    }
}
