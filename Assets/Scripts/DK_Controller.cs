using UnityEngine;
using System.Collections;

public class DK_Controller : MonoBehaviour {

	public float maxSpeed = 10F;
	bool FacingRight = true;
	Animator Anim;

	//For Fall
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	
	void Flip(){
		FacingRight = !FacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Anim.GetBool ("isDead")) {
						//Update for Fall
						grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
						Anim.SetBool ("Ground", grounded);

						Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

						float move = Input.GetAxis ("Horizontal");

						Anim.SetFloat ("Speed", Mathf.Abs (move));

						rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		 
						if (move > 0 && !FacingRight) {
								Flip ();
						} else if (move < 0 && FacingRight) {
								Flip ();
						}
				}
	}

	void Update(){

		if(CFInput.GetButtonDown("Fire1"))
		{
			Anim.SetTrigger("Throw");
		}

		if(CFInput.GetButtonDown("Jump") && grounded){
			grounded = false;
			Anim.SetBool("isDead",true);
		}

		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			Anim.SetBool ("Ground", false);
			rigidbody2D.AddForce( new Vector2(0, jumpForce));
		}
	}

}
