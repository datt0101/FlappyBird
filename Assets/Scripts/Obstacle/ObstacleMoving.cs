using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ObstacleMoving : MonoBehaviour
{
    [SerializeField] private float speed;

    public float Speed 
    { 
        get => speed;
        
        set
        {
            if (speed <= 7)
            {
                speed = value;
            }
            else
                speed = 7;
        }
    }

    private void Update()
    {
        MoveLeft();
    }
    public void InitSpeed()
    {
        speed = 2.5f;
    }
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }


}