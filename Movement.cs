using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public PlayerController controller;

    public Animator animator;

    public float runSpeed= 40f;

    public float climbspeed =0.2f;

    float horizontal =0f;

    float vertical =0f;

    bool jump;

    bool crouch;

    bool shoot;

    //bool climb;

    //[SerializeField] private float climbforce = 50f;
    //[SerializeField] private Rigidbody2D PlayerBody;

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;


        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        vertical = Input.GetAxisRaw("Vertical") * climbspeed;

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Jump1"))
        {
            jump = true;
            animator.SetBool("IsJump",true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            shoot = true;
            animator.SetBool("IsShooting",true);
        }else if(Input.GetButtonUp("Fire1"))
        {
            shoot = false;
            animator.SetBool("IsShooting",false);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJump",false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching",isCrouching);
    }

    public void OnLaddering(bool isLaddering)
    {
        animator.SetBool("IsLaddering",isLaddering);
    }
    
    private void FixedUpdate() {

        controller.Move(horizontal*Time.fixedDeltaTime, crouch, jump, vertical*Time.fixedDeltaTime,shoot);
        jump = false;
        
        
    }


    //private void OnCollisionStay2D(Collision2D other) {
//
    //    if(other.gameObject.tag == "Ladder")
    //    {
    //        PlayerBody.gravityScale=0f;
    //    }
    //    
    //}


    
}
