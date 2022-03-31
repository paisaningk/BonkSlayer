using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.BaseDog;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float playerSpeed =5;
    private Vector2 movement;
    private Vector2 MousePos;
    private PlayerDog spawnedPlayer;
    private Camera cam;
    
    private void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        MousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        
        Vector2 lookDir = MousePos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
