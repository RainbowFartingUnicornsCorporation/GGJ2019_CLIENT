using UnityEngine;

using System.Collections.Generic;

public class RessourceScript : MonoBehaviour {
    SpriteRenderer spriteRenderer;

	public int id;
	public int nbWorker;
	public int size;
	public int sizeMax;

	public GameObject FluxPrefab;


	private int nbFlux;
	private List<GameObject> fluxs;

	private float time = 0.0f;
	private float timeLastWorker = 0.0f;

    private int spriteId;
    private bool init = false;
    private static Sprite[] sprites;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

		fluxs = new List<GameObject>();
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


	void Update(){
		time += Time.deltaTime;


		updateFlux ();
	}

	private void updateFlux(){
		if (nbWorker != nbFlux) { // need to check

			if (nbWorker > nbFlux) {
				Debug.Log ("Try to worker");
				if (time - timeLastWorker > 3) {
					Debug.Log ("WORKER DONE");
					
					var newflux = Instantiate (FluxPrefab, new Vector3 (0, 0, 0), transform.rotation) as GameObject;
					var rscFlux = transform.position;
					rscFlux.y -= 4;
					newflux.GetComponent<FluxScript> ().ressource = rscFlux;
					fluxs.Add (newflux);
					timeLastWorker = time;
					nbFlux++;
				}
			}

			if (nbWorker < nbFlux) {
				//var diffToDelete = nbFlux - nbWorker;
				var flux = fluxs[0];
				fluxs.RemoveRange (0, 1);
				Destroy (flux);
				nbFlux--;
			}

		}
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
