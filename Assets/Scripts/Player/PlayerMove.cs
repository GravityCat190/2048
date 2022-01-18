using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Map map = default;
    [SerializeField]
    private ReadMap readMap = default;
    [SerializeField]
    private MoveLine moveLine = default;
    [SerializeField]
    private VoidGameEvent onPlayerMoved;

    private void Move(Square[][] MapSnapshot)
    {
        Square[] currentArray;
        int distanceMoveSum = 0;
        for (int i = 0; i < MapSnapshot.Length; i++)
        {
            currentArray = MapSnapshot[i];
            distanceMoveSum += moveLine.Move(currentArray);
        }
        CheckIfMoveHasBeenMade(distanceMoveSum);
    }

    public void MoveUp()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[Map.MapSize][];
        for (int i = 0; i < Map.MapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = readMap.ReturnColumnBackward(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveDown()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[Map.MapSize][];
        for (int i = 0; i < Map.MapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = readMap.ReturnColumn(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveLeft()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[Map.MapSize][];
        for (int i = 0; i < Map.MapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = readMap.ReturnRowBackward(i);
        }
        Move(MapSnapshotInChoosenDirection);
    }

    public void MoveRight()
    {
        Square[][] MapSnapshotInChoosenDirection = new Square[Map.MapSize][];
        for (int i = 0; i < Map.MapSize; i++)
        {
            MapSnapshotInChoosenDirection[i] = readMap.ReturnRow(i);
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
