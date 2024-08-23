using UnityEngine;

public class ObstacleHandlerCollision : MonoBehaviour
{
    public delegate void OnObstacleHandlerCollision(Collision2D collision);
    public event OnObstacleHandlerCollision OnObstacleCollision;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnObstacleCollision?.Invoke(collision);
    
    }
}


