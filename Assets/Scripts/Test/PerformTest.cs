using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformTest : MonoBehaviour
{
    [SerializeField]
    private PlayerMove PlayerMove = default;
    [SerializeField]
    private ReadMap ReadMap = default;
    [SerializeField]
    private Map Map = default;

    private List<Square> squares;
    private const int mapSize = Map.mapSize;

    private int[] startMap;
    private int[] expectedMap;
    private int[] mapAfterMoves;

    private void Awake()
    {
        squares = Map.Squares;
    }

    public bool Test(int[] startArray, int[] expectedArray)
    {
        startMap = startArray;
        expectedMap = expectedArray;

        PrepareActualBoard();
        MakeMoves();
        mapAfterMoves = ReadMapAfterTest();
        return Assert();
    }

    private void PrepareActualBoard()
    {
        for (int i = 0; i < squares.Count; i++)
        {
            squares[i].Points = startMap[i];
        }
    }

    private void MakeMoves()
    {
        PlayerMove.MoveUp();
        PlayerMove.MoveLeft();
        PlayerMove.MoveDown();
        PlayerMove.MoveRight();
    }

    private bool Assert()
    {
        for (int i = 0; i < mapSize; i++)
        {
            if (expectedMap[i] != mapAfterMoves[i])
            {
                return false;
            }
        }
        return true;
    }

    private int[] ReadMapAfterTest()
    {
        int[] result = new int[mapSize * mapSize];
        int i = 0;
        foreach (Square square in squares)
        {
            result[i] = square.Points;
            i++;
        }
        return result;
    }
}
