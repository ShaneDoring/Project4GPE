using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal")*speed;

        rigidBody.velocity = new Vector2(xMovement, rigidBody.velocity.y);

        if (rigidBody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        if (rigidBody.velocity.x < 0)
        {
            sprite.flipX = true;
        }

    }
}
