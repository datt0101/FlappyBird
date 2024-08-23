using DG.Tweening;
using TMPro;
using Unity;
using UnityEngine;



public class UIManager: MonoBehaviour
{
    static public UIManager instance;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text best;
    [SerializeField] private GameObject startedPanel;
    [SerializeField] private GameObject scoreEffect;
    [SerializeField] private GameObject bestScoreEffect;
    private void Awake()
    {
        Debug.Log("Awake");
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        TurnOn(startedPanel);
    }

    public void TurnOn(GameObject panel)
    {
        panel.SetActive(true);
        //TurnOff(scoreEffect);
        //TurnOff(bestScoreEffect);
        Time.timeScale = 0.0f;
        
    }
    public void TurnOff(GameObject panel)
    {

        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void UpdateScore()
    {
        score.text = GameManager.instance.Score.ToString();

        if (GameManager.instance.Score > 0)
        {
            ActiveAddScoreEffect(scoreEffect);
        }

        if (int.Parse(best.text) < GameManager.instance.BestScore)
        {
            best.text = GameManager.instance.BestScore.ToString();
            ActiveAddScoreEffect(bestScoreEffect);
        }
       
        
    }
    public void UpdateBestScore()
    {
        best.text = GameManager.instance.BestScore.ToString();
    }
    public void ActiveAddScoreEffect(GameObject scoreText)
    {
        scoreText.SetActive(true);   
        scoreText.transform.DOScale(1f, 0.5f)
            .OnComplete(() =>
            {
                scoreText.SetActive(false);
            });
            
    }
}