using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject instance;

    public void SetPlayer(GameObject instance)
    {
        this.instance = instance;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (instance == null) return;

        Transform transform = GetComponent<Transform>();
        Debug.Log("a");
        Debug.Log(Input.GetAxis("Vertical"));
        float translationX = Input.GetAxis("Vertical") * Time.deltaTime;
        float translationY = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Translate(translationY, translationX, 0);
    }
}
