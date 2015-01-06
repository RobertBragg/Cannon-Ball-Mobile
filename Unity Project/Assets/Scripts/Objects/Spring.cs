using UnityEngine;
using System.Collections;

public class Spring : Collide 
{
    public float springForce = 350;

    public override void OnHit(GameObject player)
    {
        base.OnHit(player);

        player.rigidbody2D.AddForce(Vector2.up * springForce);
    }
}
