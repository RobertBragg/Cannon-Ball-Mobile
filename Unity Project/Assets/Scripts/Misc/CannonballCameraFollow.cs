using UnityEngine;
using System.Collections;

public class CannonballCameraFollow : CameraFollow 
{
    public float smoothingPercent = 0.9f;

    protected override void FixedUpdate()
    {
        if (player != null)
            AdjustSmoothing();
        base.FixedUpdate();

    }

    protected void AdjustSmoothing()
    {
        ySmooth = Mathf.Abs(player.rigidbody2D.velocity.y * smoothingPercent);
    }


    protected override void TrackPlayer()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        //float targetY = transform.position.y;

        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        if (CheckYMargin())
        {
            if (player.rigidbody2D.velocity.y > 0)
            {
                targetY = Mathf.Lerp(transform.position.y, player.position.y + 3, ySmooth * Time.deltaTime);
            }
            else
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, player.position.y - 3, ySmooth * Time.deltaTime);
            }
        }

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum if they are being capped
        if (capX)
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        if (capY)
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
