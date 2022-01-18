using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject squares;
    [SerializeField]
    private FindEmptySquare findEmptySquare;

    private const int PointsAtStartSmall = 2;
    private const int PointsAtStartBig = 4;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Square squareToSpawn = findEmptySquare.GetRandomSquare();
        SetPoints(squareToSpawn);
    }

    private void SetPoints(Square square)
    {
        int pointAmount = ChoosePointAmount();
        square.Points = pointAmount;
    }

    private int ChoosePointAmount()
    {
        bool setTwoPoint = (Random.value > 0.5f);
        if (setTwoPoint)
        {
            return PointsAtStartSmall;
        }
        else
        {
            return PointsAtStartBig;
        }
    }
}
