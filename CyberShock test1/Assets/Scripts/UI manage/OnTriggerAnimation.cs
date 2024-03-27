using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour
{
    Animator m_Animator;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }
    public void Animation1(){
m_Animator.ResetTrigger("Crouch"); 
    }
}
