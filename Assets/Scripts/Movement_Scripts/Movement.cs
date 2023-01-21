using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 1000;
    public float JumpForce = 4;

    public PlayerLightingScript playerlightScript;
    private Rigidbody2D _rigidbody;

    public SpriteRenderer sprite;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (MenuManager.instance.isPause)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        if (!playerlightScript.LightIsActive)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        var movement = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(movement, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            sprite.flipX = movement > 0 ? false : true;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) <0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
