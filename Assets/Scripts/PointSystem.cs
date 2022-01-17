using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private int actualPoints = 0;
    [SerializeField]
    private TextMeshProUGUI pointsTextMesh;

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
