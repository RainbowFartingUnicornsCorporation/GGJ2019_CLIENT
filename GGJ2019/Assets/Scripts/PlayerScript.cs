using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public TextMesh textmesh;

	int food = 100;

	// Use this for initialization
	void Start () { // Get data from initialization
	}


	void MoveTo (float x, float y) {
		transform.position = new Vector3 (x, y, 0);
	}

	public void updatePlayerName(string playerName){
		textmesh.text = playerName;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
