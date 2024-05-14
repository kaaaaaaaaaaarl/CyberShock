using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : MonoBehaviour
{
    public Animator animator;
    public bool value;
    public void Load(bool value){
        animator.SetBool("Selected", value);
    }
}
