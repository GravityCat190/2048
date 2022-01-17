using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerMove PlayerMove = default;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerMove.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerMove.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerMove.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerMove.MoveRight();
        }
    }
}
