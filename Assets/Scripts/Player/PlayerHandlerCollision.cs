
using NGS.ExtendableSaveSystem;
using System.Collections;
using UnityEngine;

public class PlayerHandlerCollision : MonoBehaviour
{
    [SerializeField] private Transform initPosition;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private ObstacleManager obstacle;
    private void Start()
    {
        // Đăng ký phương thức xử lý va chạm vào sự kiện
        PlayerController.instance.OnPlayerCollision += HandleCollision;
    }

    private void OnDestroy()
    {
        // Hủy đăng ký sự kiện khi đối tượng bị phá hủy để tránh lỗi
        PlayerController.instance.OnPlayerCollision -= HandleCollision;
    }

    // Phương thức này sẽ được gọi khi phát hiện va chạm
    private void HandleCollision(Collision2D collision)
    {
        PlayerController.instance.transform.position = initPosition.position;
        obstacle.ResetPosition();
        GameMaster.instance.SaveGame();
        AudioManager.instance.PlayGameOverSound();
        UIManager.instance.TurnOn(GameOverMenu);
        Time.timeScale = 0f;
    }
}
