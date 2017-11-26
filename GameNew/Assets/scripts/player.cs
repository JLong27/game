using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	
	Animator anim;
	public GameObject bullet;

	int dir;
	float reload;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		reload = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/////////////////////////////////////////////////////////////////////////////
		/// 
		/// MOVEMENT AND SHOOTING
		/// 
		/////////////////////////////////////////////////////////////////////////////
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float xVec = 0;
		float yVec = 0;
		if (reload > 0) {
			reload = reload - 1;
		}

		if (moveVertical == 0 && moveHorizontal == 0) {
			anim.SetBool ("walking", false);
		} else {
			anim.SetBool ("walking", true);
		}

		if (Input.GetButton("Fire1") && reload == 0) {
			anim.SetInteger("dir", 1);
			xVec = 500;
			yVec = 0;

			GameObject newBul = Instantiate (bullet, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			newBul.GetComponent<Rigidbody2D> ().AddForce (new Vector2(xVec, yVec));
			reload = 10;
		}

		if (Input.GetButton("Fire2") && reload == 0) {
			anim.SetInteger("dir", 3);
			xVec = -500;
			yVec = 0;

			GameObject newBul = Instantiate (bullet, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			newBul.GetComponent<Rigidbody2D> ().AddForce (new Vector2(xVec, yVec));
			reload = 10;
		}

		if (Input.GetButton("Fire3") && reload == 0) {
			anim.SetInteger("dir", 0);
			xVec = 0;
			yVec = -500;

			GameObject newBul = Instantiate (bullet, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			newBul.GetComponent<Rigidbody2D> ().AddForce (new Vector2(xVec, yVec));
			reload = 10;
		}

		if (Input.GetButton("Fire4") && reload == 0) {
			anim.SetInteger("dir", 2);
			xVec = 0;
			yVec = 500;

			GameObject newBul = Instantiate (bullet, GetComponent<Transform> ().position, Quaternion.identity) as GameObject;
			newBul.GetComponent<Rigidbody2D> ().AddForce (new Vector2(xVec, yVec));
			reload = 10;
		}

		GetComponent<Transform>().position += (new Vector3(moveHorizontal/8, moveVertical/8, 0));
	}
}
