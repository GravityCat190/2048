using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Transform squaresContainer = default;

    private List<Square> squares = new List<Square>();

    public const int mapSize = 4;

    public List<Square> Squares 
    { 
        get => squares; 
    }

    private void Awake()
    {
        foreach (Transform child in squaresContainer)
        {
            squares.Add(child.gameObject.GetComponent<Square>());
        }
    }
}
