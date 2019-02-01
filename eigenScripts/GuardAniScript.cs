using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAniScript : MonoBehaviour
{
    
    Animator animator;
        // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed(float speedArg)
    {
        
        animator.SetFloat("speed", speedArg);
    }
    public void launchTrigger(string parameter)
    {
        animator.SetTrigger(parameter);
    }


}
