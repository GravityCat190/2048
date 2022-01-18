using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove = default;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerMove.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerMove.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerMove.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerMove.MoveRight();
        }
    }
}
