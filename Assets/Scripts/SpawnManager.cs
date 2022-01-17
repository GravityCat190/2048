using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject squares;
    [SerializeField]
    private FindEmptySquare FindEmptySquare;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Square squareToSpawn = FindEmptySquare.RandomSquare();
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
            return 2;
        }
        else
        {
            return 4;
        }
    }
}
