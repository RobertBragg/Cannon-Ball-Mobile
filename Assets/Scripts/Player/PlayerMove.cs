using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
    public float maxSpeed;
    public float tiltBuffer;

    Rigidbody2D playerBody;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move left
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x - maxSpeed * Time.deltaTime, playerBody.velocity.y);
        }
        //move right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x + maxSpeed * Time.deltaTime, playerBody.velocity.y);
        }
    }
}
