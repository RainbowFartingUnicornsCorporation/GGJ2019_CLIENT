using UnityEngine;

public class HomeScript : MonoBehaviour {

	public int food;
	public int ressources;
	public int population;
	public int foodGoal;
	public int reservePop;

	public GameObject foodNum;
	public GameObject ressourcesNum;
	public GameObject populationNum;
	public GameObject reservePopNum;

	// Use this for initialization
	void Start () {
		
	}

	public void UpdateHome(Home homeRef) {

		food = homeRef.food;
		ressources = homeRef.ressources;
		population = homeRef.population;
		foodGoal = homeRef.foodGoal;
		reservePop = homeRef.reservePop;

		foodNum.GetComponent<TextMesh> ().text = "Food " + food;
		ressourcesNum.GetComponent<TextMesh> ().text = "Ressources " + ressources;
		populationNum.GetComponent<TextMesh> ().text = "Population " + population;
		reservePopNum.GetComponent<TextMesh> ().text = reservePop + " worker idle";

	}
}
