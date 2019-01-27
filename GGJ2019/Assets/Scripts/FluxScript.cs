using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxScript : MonoBehaviour {

	private float speed = 0.1f;
	public Vector3 home;
	public Vector3 ressource;
	private bool forwardRsc = true;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		animator.SetBool("goingRight", true);

		home = new Vector3 (0, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		// move through the line between ressource and homecenter
		var rscPos = ressource;
		rscPos.z = 0;
		var myPos = this.transform.position;
		var homePos = home;

		if (forwardRsc) {
			var diff = rscPos - myPos;
			if (diff.x >= 0) {
				animator.SetBool ("goingRight", true);
			}else{
				animator.SetBool ("goingRight", false);
			}

			diff.z = 1;
			diff = diff.normalized;
			diff.x = diff.x * speed;
			diff.y = diff.y * speed;
			diff.z = 0;



			transform.Translate (diff);
			if (transform.position.magnitude > rscPos.magnitude) {
				forwardRsc = false;

			}

			if (rscPos.magnitude - transform.position.magnitude < 10 ) {
				Debug.Log ("GOOOO BACK");
				forwardRsc = false;

			}
		
		} else {
			var diff = homePos - myPos;
			if (diff.x >= 0) {
				animator.SetBool ("goingRight", true);
			}else{
				animator.SetBool ("goingRight", false);
			}

			diff.z = 1;
			diff = diff.normalized;
			diff.x = diff.x * speed;
			diff.y = diff.y * speed;
			diff.z = 0;
			this.transform.Translate (diff);

			if (transform.position.magnitude < 10.0 ) {
				Debug.Log ("TRUE");
				forwardRsc = true;

			}

		}

	
		
		
	}
}
