using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{


    
    public bool isCrouched = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {


            animator.SetFloat("Speed", 3);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("Speed", 6);
                IsCrouching(false);
            }
            else
            {
                animator.SetFloat("Speed", 3);
            }

        }
        else
        {
            animator.SetFloat("Speed", 0);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            IsCrouching(!isCrouched);

        }
        
        
    }
    public void IsCrouching(bool crouch)
    {
        isCrouched = crouch;
        
        animator.SetBool("Crouched", isCrouched);
    }
    
}
