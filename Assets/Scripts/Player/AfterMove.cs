using UnityEngine;

public class AfterMove : MonoBehaviour
{
    [SerializeField]
    private SpawnManager SpawnManager = default;
    [SerializeField]
    private GameOver GameOver;

    public void MakeActions()
    {
        SpawnManager.Spawn();
        GameOver.Check();
    }
}
