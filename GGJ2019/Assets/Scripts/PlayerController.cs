using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool atHome = true;
    private GameObject instance;
    private Animator animator;

    public float speed = 15;

    public void SetPlayer(GameObject instance)
    {
        this.instance = instance;
    }

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (instance == null) return;

        Transform transform = GetComponent<Transform>();

        float translationX = speed * Input.GetAxis("Vertical") * Time.deltaTime;
        float translationY = speed * Input.GetAxis("Horizontal") * Time.deltaTime;

        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);

        if (Input.GetAxis("Vertical") > 0)
            animator.SetBool("Up", true);
        else if (Input.GetAxis("Vertical") < 0)
            animator.SetBool("Down", true);
        else if(Input.GetAxis("Horizontal") < 0)
            animator.SetBool("Left", true);
        else if (Input.GetAxis("Horizontal") > 0)
            animator.SetBool("Right", true);

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
