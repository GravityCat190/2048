using System;
using System.Collections.Generic;
using UnityEngine;

public class ReadMap : MonoBehaviour
{
    [SerializeField]
    private Map Map = default;

    private List<Square> squares = default;

    private Square[,] rows = new Square[mapSize,mapSize];
    private Square[,] columns = new Square[mapSize, mapSize];

    private const int mapSize = Map.mapSize;

    private void Awake()
    {
        squares = Map.Squares;
    }

    private void Start()
    {
        int currentIndex;
        for (int row = 0; row < mapSize; row++)
        {
            for (int column = 0; column < mapSize; column++)
            {
                currentIndex = row * mapSize + column;

                rows[row,column] = squares[currentIndex];
                columns[column,row] = squares[currentIndex];

                squares[currentIndex].Row = row;
                squares[currentIndex].Column = column;
            }
        }
    }

    public Square[] ReturnRow(int index)
    {
        Square[] result = new Square[mapSize];
        for (int i = 0; i < mapSize; i++)
        {
            result[i] = rows[index, i];
        }
        return result;
    }

    public Square[] ReturnRowBackward(int index)
    {
        int currentIndex;
        Square[] result = new Square[mapSize];
        for (int i = mapSize - 1; i >= 0; i--)
        {
            currentIndex = mapSize - i - 1; // 4(mapSize) - 3(startIndex) - 1(offset)
            result[currentIndex] = rows[index, i];
        }
        return result;
    }

    public Square[] ReturnColumn(int index)
    {
        Square[] result = new Square[mapSize];
        for (int i = 0; i < mapSize; i++)
        {
            result[i] = columns[index, i];
        }
        return result;
    }

    public Square[] ReturnColumnBackward(int index)
    {
        int currentIndex;
        Square[] result = new Square[mapSize];
        for (int i = mapSize - 1; i >= 0; i--)
        {
            currentIndex = mapSize - i - 1; // 4(mapSize) - 3(startIndex) - 1(offset)
            result[currentIndex] = columns[index, i];
        }
        return result;
    }
}
