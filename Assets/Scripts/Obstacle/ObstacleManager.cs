using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    static public ObstacleManager instance;
    [SerializeField] private ObstacleHandlerCollision[] obstacleCollisions;
    [SerializeField] private Transform initTransform;
    [SerializeField] private ObstacleMoving obstacleMoving;
    [SerializeField] private float ymin, ymax, distance, padding;

    public ObstacleMoving ObstacleMoving { get => obstacleMoving; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        foreach (var obstacle in obstacleCollisions)
        {
            obstacle.OnObstacleCollision += HandleCollision;
        }
        InitYminYmax();
    }

    private void OnDestroy()
    {
        foreach (var obstacle in obstacleCollisions)
        {
            obstacle.OnObstacleCollision -= HandleCollision;
        }
    }
    void InitYminYmax()
    {
        Camera camera = Camera.main;
        distance = camera.transform.position.z - transform.position.z;
        //chuyen view (1,1) (0,0) sang world ( mat phang transform)
        ymax = (camera.ViewportToWorldPoint(new Vector3(1, 1, distance)).y + padding) / 2;
        ymin = (camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).y - padding) / 2;
    }


    public void ResetPosition()
    {
        //Debug.Log("ymax: " + ymax + " - ymin: " + ymin);
        transform.position = new Vector3(
                            initTransform.position.x,
                            Random.Range(ymin, ymax),
                            initTransform.position.z);
    }
    public void HandleCollision(Collision2D collision)
    {
        ResetPosition();
    }
}