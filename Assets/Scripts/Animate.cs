using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour 
{
    [HideInInspector]   public int _animState = Animator.StringToHash("AnimState");
    protected Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimState(int stateNum)
    {
        //Debug.Log(stateNum);
        _animator.SetInteger(_animState, stateNum);
    }
}
