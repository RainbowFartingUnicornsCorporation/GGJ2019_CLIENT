using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPlacer : MonoBehaviour {
	void Start () {
		foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            Transform tr = sr.GetComponent<Transform>();
            Vector3 vec = new Vector3(tr.position.x, tr.position.y, tr.position.y);
            tr.position = vec;
        }
	}
}
