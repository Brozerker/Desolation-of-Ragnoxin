using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour 
{
	public float maxSpeed = 8f;
	public int speed;
	public float jumpForceFactor = 2.5f; //in 10,000s
	float jumpForce;
	bool doubleJump = true; //double jump already used = true
	bool grounded = false; //on ground?
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Animator animator;
	Vector3 playerPos;
	Transform playerTransform;

	bool facingRight = true;




    void Start() {

        animator = GetComponent<Animator>();
		jumpForce = jumpForceFactor * 10000; //jump multiplier
		playerTransform = GameObject.Find ("Player").transform;
    }   

	void Update()
	{
		playerPos = playerTransform.position;
	
		//JUMP CONTROL
		if((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f); //reset upwards/downwards velocity before jumping (helps with second jump)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			if(!doubleJump && !grounded)
			{
				doubleJump = true;
			}
		}

		// Reset Level Key
		if(Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		// Fallen out of the world detection
		if (playerPos.y < -10) {
			// add code to reduce 'hp' by one
			Application.LoadLevel(Application.loadedLevel);
		}

		//OLD ANIMATION CODE DELETE IF NO LONGER NEEDED
		//if(Input.GetKey("left")) {
         //   animator.SetBool("moveLeft", true);
        //}
        //if (Input.GetKey("right")) {
          //  animator.SetBool("moveLeft", false);
       // }

	}
    void FixedUpdate() 
	{
		//check if player is on ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (grounded)
			doubleJump = false; //if player not on ground, give double jump.

		//Uncomment this to make it to where the player cannot turn while in the air.
		//if (!grounded)
			//return;

		//move left and right
		float move = Input.GetAxis ("Horizontal"); //get input direction (+/- value)
		//animator.SetFloat ("Speed", Mathf.Abs (move)); //apply movement direction to variable for animation (+/- value)


		//animation for left/right
		if (move > 0 && !facingRight) {
			Flip ();
		}
		else if (move < 0 && facingRight) {
			Flip ();
		}

		//actual movement change
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
	void Flip()//flip animation for sprite
	{
		facingRight = !facingRight; //reverse current direction
		Vector3 theScale = transform.localScale;
		theScale.x *= -1; //flip the transform of the sprite
		transform.localScale = theScale;
	}
}