using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    public Camera cam;


    void Update()
    {
        moveSpeed = FindObjectOfType<GameManager>().moveSpeed;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // aim
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        moveSpeed = FindObjectOfType<GameManager>().moveSpeed;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //aim
        Vector2 dirLook = mousePos - rb.position;
        float angle = Mathf.Atan2(dirLook.y, dirLook.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
