using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxScript : MonoBehaviour {

	private float speed = 0.1f;
	public GameObject home;
	public GameObject ressource;
	private bool forwardRsc = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// move through the line between ressource and homecenter
		var rscPos = ressource.transform.position;
		var myPos = this.transform.position;
		var homePos = home.transform.position;

		if (forwardRsc) {
			var diff = rscPos - myPos;
			if (diff.magnitude < 1) {
				forwardRsc = false;
			}
			diff.z = 1;
			diff = diff.normalized;
			diff.x = diff.x * speed;
			diff.y = diff.y * speed;
			diff.z = 0;



			this.transform.Translate (diff);
			if (this.transform.position.magnitude > rscPos.magnitude) {
				forwardRsc = false;
			}
		
		} else {
			var diff = homePos - myPos;
			if (diff.magnitude < 1) {
				forwardRsc = true;
			}
			diff.z = 1;
			diff = diff.normalized;
			diff.x = diff.x * speed;
			diff.y = diff.y * speed;
			diff.z = 0;
			if (diff.magnitude == 0) {
				forwardRsc = true;
			}
			this.transform.Translate (diff);
			if ((this.transform.position.x * rscPos.x) < 0) {
				forwardRsc = true;
			}

		}

	
		
		
	}
}
