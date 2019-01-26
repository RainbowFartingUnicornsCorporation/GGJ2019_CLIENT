using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool atHome = true;
    private GameObject instance;
    public float speed = 5;

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

        float translationX = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        float translationY = speed * Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Translate(translationY, translationX, 0);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Home")
        {
            atHome = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Resource")
        {
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Home")
        {
            atHome = false;
        }
    }
}
