using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Map Map = default;
    [SerializeField]
    private ReadMap ReadMap = default;
    [SerializeField]
    private MoveLine MoveLine = default;
    [SerializeField]
    private VoidGameEvent onPlayerMoved;

    private const int mapSize = Map.mapSize;

    private void Move(Square[][] MapSnapshot)
    {
        Square[] currentArray;
        int distanceMoveSum = 0;
        for (int i = 0; i < MapSnapshot.Length; i++)
        {
            currentArray = MapSnapshot[i];
            distanceMoveSum += MoveLine.Move(currentArray);
        }
        CheckIfMoveHasBeenMade(distanceMoveSum);
    }

    public void MoveUp()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[mapSize][];
        for (int i = 0; i < mapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = ReadMap.ReturnColumnBackward(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveDown()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[mapSize][];
        for (int i = 0; i < mapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = ReadMap.ReturnColumn(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveLeft()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[mapSize][];
        for (int i = 0; i < mapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = ReadMap.ReturnRowBackward(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveRight()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[mapSize][];
        for (int i = 0; i < mapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = ReadMap.ReturnRow(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    private void CheckIfMoveHasBeenMade(int distanceMoveSum)
    {
        bool isMove = distanceMoveSum != 0;
        if (isMove)
        {
            onPlayerMoved?.Raise();
        }
    }
}
