using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public TextMesh textmesh;
	public Camera mainCamera;
	public int food = 100;
	private bool init = false;
	public int inventory;
	public int maxFood;
	public int maxInventory;
	public GameObject maxFoodText;
	public GameObject maxInventoryText;
	public GameObject foodText;
	public GameObject inventoryText;

	void MoveTo (float x, float y) {
		transform.position = new Vector3 (x, y, y);
	}

	public void UpdatePlayer(Player playerRef){
		if (init == false) {
			textmesh.text = playerRef.name;
			init = true;
		}

		// Update the player with server data
		food = playerRef.food;
		maxFood = playerRef.maxFood;
		maxInventory = playerRef.maxInventory;
		inventory = playerRef.inventory;

        if (food <= 0)
        {
            GameOver.GetInstance().SetActive(true);
        }

		maxFoodText.GetComponent<Text>().text = "/ "+maxFood.ToString();
		maxInventoryText.GetComponent<Text>().text = "/ "+maxInventory.ToString();
		foodText.GetComponent<Text>().text = food.ToString();
		inventoryText.GetComponent<Text>().text = inventory.ToString();
	}

	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, mainCamera.transform.position.z);		
	}
}
