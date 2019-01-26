using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceScript : MonoBehaviour {

	private bool init = false;
	public int id;
	public int nbWorker;
	public int size;
	public int sizeMax;


	// Use this for initialization
	void Start () {
		
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
