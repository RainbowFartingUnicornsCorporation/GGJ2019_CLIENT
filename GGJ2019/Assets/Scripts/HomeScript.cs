using UnityEngine;

public class HomeScript : MonoBehaviour {

	public int food;
	public int ressources;
	public int population;
	public int foodGoal;
	public int reservePop;

	// Use this for initialization
	void Start () {
		
	}

	public void UpdateHome(Home homeRef) {

		food = homeRef.food;
		ressources = homeRef.ressources;
		population = homeRef.population;
		foodGoal = homeRef.foodGoal;
		reservePop = homeRef.reservePop;

	}
}
