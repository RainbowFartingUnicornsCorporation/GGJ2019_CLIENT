using UnityEngine;

public class RessourceScript : MonoBehaviour {
    SpriteRenderer spriteRenderer;

	public int id;
	public int nbWorker;
	public int size;
	public int sizeMax;

    private int spriteId;
    private bool init = false;
    private static Sprite[] sprites;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites == null)
        {
            sprites = new Sprite[3];
            sprites[0] = Resources.Load<Sprite>("Sprites/Landscape_0");
            sprites[1] = Resources.Load<Sprite>("Sprites/Landscape_1");
            sprites[2] = Resources.Load<Sprite>("Sprites/Landscape_2");
        }
    }

	public int getId(){
		return id;
	}

	public void UpdateRessource(Ressource ressourceRef){
		// initialisation
		if (init == false) {
			id = ressourceRef.id;
			init = true;
		}

		//update this ressource
		nbWorker = ressourceRef.nbWorker;
		size = ressourceRef.size;
		sizeMax = ressourceRef.sizeMax;
    }

    void OnGUI()
    {
        if (size == 0 && spriteId != 0)
        {
            spriteId = 0;
            spriteRenderer.sprite = sprites[spriteId];
        }
        else if (size <= sizeMax/2 && spriteId != 1)
        {
            spriteId = 1;
            spriteRenderer.sprite = sprites[spriteId];
        }
        else if (spriteId != 2)
        {
            spriteId = 2;
            spriteRenderer.sprite = sprites[spriteId];
        }
    }
}
