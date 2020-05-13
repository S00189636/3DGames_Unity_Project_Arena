using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        //Animator.SetTrigger("StartScrolling");
        Animator.SetBool("Scroll",true);
        print("it should be on ");
    }



    
}
