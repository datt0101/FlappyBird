using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        TouchTheScreen();
    }
    public void TouchTheScreen()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (IsPointerOverUIObject())
                {
                    Debug.Log("UI");
                    return; // Không xử lý chạm nếu nó nằm trên thành phần UI.
                }

                AudioManager.instance.PlayJumpSound();
                PlayerController.instance.AddForceToChar();
            }
        }
    }
    private bool IsPointerOverUIObject()
    {
        // Kiểm tra nếu chạm lên thành phần UI.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}