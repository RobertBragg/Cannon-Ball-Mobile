using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float xSmooth = 1f;
	public float yMargin = 1f; 		// Distance in the y axis the player can move before the camera follows.
	public float ySmooth = 1f;
    public bool capX;
    public bool capY;
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.


	public Transform player;		// Reference to the player's transform.

    protected virtual bool CheckXMargin()
	{
		//Debug.Log("CheckX: " + (Mathf.Abs(transform.position.x - player.position.x) > xMargin));
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
    protected virtual bool CheckYMargin()
	{
		//Debug.Log("CheckY: " + (Mathf.Abs(transform.position.y - player.position.y) > yMargin));
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}


	protected virtual void FixedUpdate ()
	{
        if(player != null)
		    TrackPlayer();
	}

	
	protected virtual void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		//float targetY = transform.position.y;

		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		if(CheckYMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum if they are being capped
        if(capX)
		    targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        if(capY)
		    targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
