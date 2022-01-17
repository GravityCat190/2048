using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pointText = default;

    [SerializeField]
    private int points;
    private int row;
    private int column;

    public int Points
    {
        get => points;
        set
        {
            points = value;
            UpdateText();
        }
    }
    public int Row 
    { 
        get => row; 
        set => row = value; 
    }
    public int Column 
    { 
        get => column; 
        set => column = value; 
    }

    public bool IsEmpty => points == 0;

    private void UpdateText()
    {
        if (points == 0)
        {
            pointText.text = "";
        }
        else
        {
            pointText.text = points.ToString();
        }
    }
}
