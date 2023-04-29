using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody2D rb;

    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * fixedJoystick.Vertical + Vector2.down * fixedJoystick.Horizontal;
        rb.velocity = direction * Time.deltaTime * speed;
    }
}