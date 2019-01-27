using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerScript : MonoBehaviour {

	public string name = "idkyet";
	public TextMesh textmesh;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		animator.SetBool("goingRight", false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setName(string name){
		this.name = name;
		textmesh.text = name;
	}

	public void UpdatePosition (float posX, float posY) {
		transform.position = new Vector3 (posX, posY, posY);
	}
}
