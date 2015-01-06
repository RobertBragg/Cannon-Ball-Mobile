using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Launch : MonoBehaviour 
{
    public float maxLaunchVelocity;
    public float minLaunchVelocity;
    bool increasing;
    public float fillRate;

    public Image bar;

    Rigidbody2D playerBody;
    Animate pAnim;
    PlayerMove pMove;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        pMove = GetComponent<PlayerMove>();
        pMove.enabled = false;
        pAnim = GetComponent<Animate>();
        playerBody.gravityScale = 0;
        increasing = true;
    }

    void Update()
    {
        //check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if input, do launch and destroy this
            float delta = maxLaunchVelocity - minLaunchVelocity;
            float multiplier = minLaunchVelocity + (delta * bar.fillAmount);
            playerBody.AddForce(Vector2.up * multiplier);
            playerBody.gravityScale = 1;
            pMove.enabled = true;
            pAnim.SetAnimState(1);
            Destroy(bar.transform.parent.parent.gameObject);
            Destroy(this);
        }
        //else move the meter
        if (increasing)
        {
            bar.fillAmount += Time.deltaTime * fillRate;
            if (bar.fillAmount >= 1)
            {
                increasing = false;
            }
        }
        else
        {
            bar.fillAmount -= Time.deltaTime * fillRate;
            if (bar.fillAmount <= 0)
            {
                increasing = true;
            }
        }
    }

}
