using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public TextMesh textmesh;

	public int food = 100;
	private bool init = false;
	public int inventory;
	public int maxFood;
	public int maxInventory;

	// Use this for initialization
	void Start () { // Get data from initisalization
	}


	void MoveTo (float x, float y) {
		transform.position = new Vector3 (x, y, 0);
	}

	public void updatePlayer(Player playerRef){
		if (init == false) {
			textmesh.text = playerRef.name;
			init = true;
		}

		// Update the player with server data
		food = playerRef.food;
		maxFood = playerRef.maxFood;
		maxInventory = playerRef.maxInventory;
		inventory = playerRef.inventory;


	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
