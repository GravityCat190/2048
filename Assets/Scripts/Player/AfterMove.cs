using UnityEngine;

public class AfterMove : MonoBehaviour
{
    [SerializeField]
    private SpawnManager spawnManager = default;
    [SerializeField]
    private GameOver gameOver;

    public void MakeActions()
    {
        spawnManager.Spawn();
        gameOver.Check();
    }
}
