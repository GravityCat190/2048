using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int Row;
    public int Column;

    [SerializeField]
    private TMP_Text pointText = default;
    
    private int points;

    public int Points
    {
        get => points;
        set
        {
            points = value;
            UpdateText();
        }
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
