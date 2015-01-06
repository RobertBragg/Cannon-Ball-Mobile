using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
    public GameObject splashObj;

    void OnTriggerEnter2D(Collider2D col)
    {
        //if the player collides with the water
        if (col.tag == "Player")
        {
            //instantiate splash on players position
            GameObject splash = (GameObject)Instantiate(splashObj, col.transform.position, Quaternion.identity);
            //adjust size based on player's velocity
            splash.transform.localScale *= -1 * col.rigidbody2D.velocity.y / 10;
            //destroy player
            Destroy(col.gameObject);
        }
    }
}
