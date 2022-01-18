using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsTextMesh;

    private int actualPoints = 0;

    private void Start()
    {
        UpdatePoints();
    }

    public void AddPoints(int pointsToAdd)
    {
        actualPoints += pointsToAdd;
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        pointsTextMesh.text = "Points: " + actualPoints.ToString();
    }
}
