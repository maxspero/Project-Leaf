using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 2;
	private float speed;
	bool facingRight = false;
	Animator anim;
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		speed = Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x);
		anim.SetFloat ("Speed", speed);
	}

	public void MoveRight() {
		if (!facingRight) {
			Flip ();
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void MoveLeft() {
		if (facingRight) {
			Flip ();
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void Stop() {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
	}

	public void Jump() {

	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
