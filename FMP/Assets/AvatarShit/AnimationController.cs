using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    CharacterMovement speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool sprint = Input.GetKey("left shift");

        bool movement = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        //walking
        if (!isWalking && movement)
        {
            animator.SetBool(isWalkingHash, true);
        }

        //stop walking
        if (isWalking && !movement) 
        {
            animator.SetBool(isWalkingHash, false);
        }

        //start sprinting
        if(movement && sprint) 
        {
            animator.SetBool("isRunning", true);
        }

        //stop sprinting
        if (!movement || !sprint)
        {
            animator.SetBool("isRunning", false);
        }
    }
}
