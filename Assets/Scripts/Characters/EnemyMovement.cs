using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("hitting player");
    }
}
