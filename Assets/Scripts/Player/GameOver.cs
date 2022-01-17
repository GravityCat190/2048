using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private FindEmptySquare FindEmptySquare;
    [SerializeField]
    private CheckMapForPossibleMove CheckMapForPossibleMove;


    public void Check()
    {
        bool isOver = CheckIfMapIsFull();
        if (isOver)
        {
            isOver = CheckIfPlayerCanMove();
        }
        if (isOver)
        {
            ResetGame();
        }
    }

    private bool CheckIfMapIsFull()
    {
        if (FindEmptySquare.FirstSquare() != null)
        {
            return false;
        }
        return true;
    }

    private bool CheckIfPlayerCanMove()
    {
        if (CheckMapForPossibleMove.IsPossible())
        {
            return false;
        }
        return true;
    }

    private void ResetGame()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
