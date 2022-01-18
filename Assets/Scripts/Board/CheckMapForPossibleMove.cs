using UnityEngine;

public class CheckMapForPossibleMove : MonoBehaviour
{
    [SerializeField]
    private Map map = default;
    [SerializeField]
    private CheckSquareNeighbors checkSquareNeighbors = default;

    public bool IsPossible()
    {
        foreach (Square square in map.Squares)
        {
            if (checkSquareNeighbors.IsPossibleToMoveOnNeighbors(square))
            {
                return true;
            }
        }

        return false;
    }
}
