using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour 
{
	public float maxSpeed = 10f;
    public int speed;
	bool grounded = false; //on ground?
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 50;
	bool doubleJump = true; //double jump already used = true

	void Update()
	{
		if((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			if(!doubleJump && !grounded)
			{
				doubleJump = true;
			}
		}

	}
    void FixedUpdate() 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		if (grounded)
			doubleJump = false;

		if (!grounded)
			return;
		//move left and right
		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}