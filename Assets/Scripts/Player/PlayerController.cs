using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;
    private Rigidbody2D playerRigidbody;
    [SerializeField] private float playerForce;

    public delegate void OnPlayerCollisionHandler(Collision2D collision);
    public event OnPlayerCollisionHandler OnPlayerCollision;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddForceToChar();
    }
   
    public void AddForceToChar()
    {
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(Vector2.up * playerForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerCollision?.Invoke(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CalculatePoint")
        {
            //Debug.Log("Trigger");
            GameManager.instance.AddPoint();
            AudioManager.instance.PlayGetPointSound();
            UIManager.instance.UpdateScore();
        }
    }
}
