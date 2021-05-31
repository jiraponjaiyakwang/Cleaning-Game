using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ctrl_Player : MonoBehaviour
{
    Animator anim;
	Rigidbody2D rb;
	float moveX;
	public float jumpForce = 600f, moveSpeed = 5f;
	int playerLayer, platformLayer;
	bool jumpOffCoroutineIsRunning = false;


	// Use this for initialization
	void Start () 
	{
        anim = GetComponent<Animator>();

		rb = GetComponent<Rigidbody2D> ();
		playerLayer = LayerMask.NameToLayer ("Player");
		platformLayer = LayerMask.NameToLayer ("Platform");
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveX = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump"))
		{
			anim.SetInteger("Animation", 3);
		}

		if (Input.GetButtonDown ("Jump") && !Input.GetKey (KeyCode.S) && rb.velocity.y == 0) 
		{
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Force);
			//print("Jump");
		} 
		else if (Input.GetButtonDown ("Jump") && Input.GetKey (KeyCode.S) && !jumpOffCoroutineIsRunning) 
		{
			StartCoroutine ("JumpOff");
		}
	
		if (rb.velocity.y > 0)
		{
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		}
		
		else if (rb.velocity.y <= 0 && !jumpOffCoroutineIsRunning)
		{
			Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
		}


		if(moveX < 0)
		{
			
			transform.eulerAngles = new Vector3(0,180,0);
			anim.SetInteger("Animation", 1);
		}

		else if(moveX > 0)
		{
			transform.eulerAngles = new Vector3(0,0,0);
			anim.SetInteger("Animation", 1);
		}
		else if(moveX == 0)
		{
			transform.eulerAngles = new Vector3(0,0,0);
			anim.SetInteger("Animation", 0);
		}
	}
	void FixedUpdate()
	{
		rb.velocity = new Vector2 (moveX * moveSpeed, rb.velocity.y);
	}

	IEnumerator JumpOff()
	{
		jumpOffCoroutineIsRunning = true;
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
		yield return new WaitForSeconds (0.5f);
		Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
		jumpOffCoroutineIsRunning = false;
	}
}
