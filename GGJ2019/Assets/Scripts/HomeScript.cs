using UnityEngine;

public class HomeScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private static Sprite[] sprites;
    private int spriteId;

    public int food;
	public int ressources;
	public int population;
	public int foodGoal;
	public int reservePop;

	public GameObject foodNum;
	public GameObject ressourcesNum;
	public GameObject populationNum;
	public GameObject reservePopNum;
    
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteId = 0;

        if (sprites == null)
        {
            sprites = new Sprite[3];
            sprites[0] = Resources.Load<Sprite>("Sprites/Home_1");
            sprites[1] = Resources.Load<Sprite>("Sprites/Home_2");
            sprites[2] = Resources.Load<Sprite>("Sprites/Home_3");
        }
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

    void OnGUI()
    {
        if (spriteId == 0 && population > 0 ||
            spriteId == 1 && population > 4 ||
            spriteId == 2 && population > 9)
        {
            Destroy(GetComponent<Animator>());
            spriteRenderer.sprite = sprites[spriteId];
            spriteId++;
        }
    }
}
