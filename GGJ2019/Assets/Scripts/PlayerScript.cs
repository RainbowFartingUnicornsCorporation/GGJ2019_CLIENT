using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public TextMesh textmesh;

	int food = 100;

	// Use this for initialization
	void Start () { // Get data from initialization
		textmesh.text = "PlayerNameSetted";
	}


	void MoveTo (float x, float y) {
		transform.position = new Vector3 (x, y, 0);
	}

	void updatePlayerName(string PlayerName){
		

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
