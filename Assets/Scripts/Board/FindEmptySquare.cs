using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FindEmptySquare : MonoBehaviour
{
    [SerializeField]
    private Map Map;

    private const int mapSize = Map.mapSize;
    private List<Square> squares;

    int squaresAmount = mapSize * mapSize;

    private void Awake()
    {
        squares = Map.Squares;
    }

    public Square RandomSquare()
    {
        Square square = TryFindRandomSquare();
        if (square == null)
        {
            square = FirstSquare();
        }

        return square;
    }

    private Square TryFindRandomSquare()
    {
        int randomIndex = Random.Range(0, squaresAmount);
        int points;
        for (int i = randomIndex; i < squaresAmount; i++)
        {
            points = squares[i].Points;
            bool squareIsNotEmpty = Convert.ToBoolean(points);
            if (!squareIsNotEmpty)
            {
                return squares[i];
            }
        }
        return null;
    }

    public Square FirstSquare()
    {
        int points;
        for (int i = 0; i < squaresAmount; i++)
        {
            points = squares[i].Points;
            bool squareIsNotEmpty = Convert.ToBoolean(points);
            if (!squareIsNotEmpty)
            {
                return squares[i];
            }
        }
        return null;
    }
}
