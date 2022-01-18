using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public const int MapSize = 4;

    [SerializeField]
    private Transform squaresContainer = default;

    private List<Square> squares = new List<Square>();

    public List<Square> Squares 
    { 
        get => squares; 
    }

    private void Awake()
    {
        FillSquaresList();
    }

    private void FillSquaresList()
    {
        foreach (Transform child in squaresContainer)
        {
            squares.Add(child.gameObject.GetComponent<Square>());
        }
    }
}
