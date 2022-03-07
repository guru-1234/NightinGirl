using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce=1000f;
    [Range(0,3f)][SerializeField] private float m_smoothingVelocity =.05f; 
    [SerializeField] private LayerMask m_whatisGround;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_CeilingCheck;
    [SerializeField] private bool m_AirControll = false;
	//[SerializeField] private GameObject checker;
	[SerializeField] private Collider2D OnCrouchingDisableCollider;
    [SerializeField] private GameObject NormalGun;
    [SerializeField] private GameObject RunningGun;
    [SerializeField] private GameObject CrouchGun;
    [SerializeField] private GameObject BulletPrefab;
	



    const float m_GroundRadius =.2f;
	private bool m_Grounded;
    //const float m_CeilingRadius =.02f;
	private Rigidbody2D playerRigidBody;
    private bool isFacingRight = true;
	private bool isLadder;
    private Vector3 m_cameraveloctiy=Vector3.zero;
    private float alreadyRunning;
    
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
	private bool already_Crouching=false;

	[System.Serializable]

	public class LadderBoolEvent : UnityEvent<bool>{ }

	public LadderBoolEvent OnLadderEvent;

	//private bool ladderAhead = false;

    // Start is called before the first frame update
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        if(OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
        if(OnCrouchEvent == null)
        {
            OnCrouchEvent = new BoolEvent();
        }
		if(OnLadderEvent == null)
        {
            OnLadderEvent = new LadderBoolEvent();
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
		//bool was_Ladder = isLadder;
        bool wasGrounded = m_Grounded;
        m_Grounded = false;
		//isLadder =false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position,m_GroundRadius,m_whatisGround);


        for(int i=0;i<colliders.Length;i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if(!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }

		//if(!was_Ladder)
		//{
		//	OnLadderEvent.Invoke(false);
		//}else if(was_Ladder)
		//{
		//	OnLadderEvent.Invoke(true);
		//}
    }

	private void OnTriggerEnter2D(Collider2D collision1) {
        
	
			if(collision1.CompareTag("Ladder"))
        	{
            	isLadder = true;
        	}

            if(collision1.CompareTag("MovingPlatForm"))
            {
                transform.parent = collision1.gameObject.transform;
                playerRigidBody.gravityScale=0f;
            }
        
    }
    

    private void OnTriggerExit2D(Collider2D collision2) {

	    	if(collision2.CompareTag("Ladder"))
        	{
				playerRigidBody.gravityScale=3f;
            	isLadder = false;
           	 	Debug.Log("IT OK");
        	}

            if(collision2.CompareTag("MovingPlatForm"))
            {
                transform.parent = null;
                playerRigidBody.gravityScale=3f;
            }
        
    }

    public void Move(float horizontal,bool crouch, bool jump, float climb,bool shoot)
    {
        //if(!crouch)
        //{
        //    if(Physics2D.OverlapCircle(m_CeilingCheck.position,m_CeilingRadius,m_whatisGround))
        //    {
        //        crouch = true;
        //    }
        //     
        //}
        alreadyRunning = horizontal;
        if(m_Grounded || m_AirControll)
        {
            if(crouch)
            {
                if(!already_Crouching)
                {
                    already_Crouching = true; 
                    OnCrouchEvent.Invoke(true); //ITS a bool u fool
                }

                if(OnCrouchingDisableCollider!=null)
                {
                    OnCrouchingDisableCollider.enabled = false;
                }
                
            }else
			{

                if(OnCrouchingDisableCollider!=null)
                    OnCrouchingDisableCollider.enabled = true;
               
                if(already_Crouching)
                {
                    already_Crouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
        
            Vector3 targetVelocity = new Vector2(horizontal* 10f, playerRigidBody.velocity.y);
    
            playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity,targetVelocity,ref m_cameraveloctiy,m_smoothingVelocity);
	
            if(horizontal>0 && !isFacingRight)
            {
                flipSide();
            }
			else if(horizontal<0 && isFacingRight)
            {
                flipSide();
            }

			if(isLadder)
			{
				OnLadderEvent.Invoke(true);
				playerRigidBody.gravityScale =0f;
				Vector3 LadderVelocity = new Vector2(playerRigidBody.velocity.x,climb* 10f);
				playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity,LadderVelocity,ref m_cameraveloctiy,m_smoothingVelocity);
			}else if(!isLadder)
			{
				OnLadderEvent.Invoke(false);
			}
		}
		if(m_Grounded && jump)
        {
            m_Grounded = false;
            playerRigidBody.AddForce(new Vector2(0f,jumpForce));
	    }

        if(shoot)
        {
                if(m_Grounded && !crouch && alreadyRunning<0.01)
                {
                    Instantiate(BulletPrefab,NormalGun.transform.position,NormalGun.transform.rotation);
                }
                if(m_Grounded && crouch && alreadyRunning<0.01)
                {
                    Instantiate(BulletPrefab,CrouchGun.transform.position,CrouchGun.transform.rotation);
                }
                if(m_Grounded && alreadyRunning>0.01 && !crouch)
                {
                    Instantiate(BulletPrefab,RunningGun.transform.position,RunningGun.transform.rotation);
                    
                }
        }
        

    }

    private void flipSide()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(new Vector3(0f,180f,0f));
		//Vector3 theScale = transform.localScale;
		//theScale.x *= -1;
		//transform.localScale = theScale;
    }
    
}
