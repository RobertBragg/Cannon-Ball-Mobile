using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour
{
    protected Animator pAnim;


    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pAnim = col.GetComponent<Animator>();
            OnHit(col.gameObject);
        }
    }

    public virtual void OnHit(GameObject player)
    {
    }
}
