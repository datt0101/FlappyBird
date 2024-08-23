using NGS.ExtendableSaveSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    private int score;
    private int bestScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
        score = 0;
    }
    private void Start()
    {
        Application.targetFrameRate = 120;
        GameMaster.instance.LoadGame();   
    }
    public int Score { get => score; set => score = value; }
    public int BestScore { get => bestScore; set => bestScore = value; }

    public void AddPoint()
    {
        score++;
        if (bestScore < score)
        {
            bestScore = score;
        }
        UpgradeSpeedOfGame();
    }

    public void UpgradeSpeedOfGame()
    {
        if(score % 5 == 0)
        {
            ObstacleManager.instance.ObstacleMoving.Speed += 0.5f;
        }
    }
    public void RestartGame()
    {
        score = 0;
        ObstacleManager.instance.ObstacleMoving.InitSpeed();
        UIManager.instance.UpdateScore();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}