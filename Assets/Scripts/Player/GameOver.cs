using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private FindEmptySquare findEmptySquare;
    [SerializeField]
    private CheckMapForPossibleMove checkMapForPossibleMove;

    public void Check()
    {
        if (IsMapFull() && CanPlayerMove())
        {
            ResetGame();
        }
    }

    private bool IsMapFull()
    {
        if (findEmptySquare.GetFirstSquare() != null)
        {
            return false;
        }
        return true;
    }

    private bool CanPlayerMove()
    {
        if (checkMapForPossibleMove.IsPossible())
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
