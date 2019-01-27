using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool atHome;
    private bool atResource;
    private GameObject instance;
    private Animator animator;
    private PlayerScript ps;

    public float speed = 15;

    public void SetPlayer(GameObject instance)
    {
        this.instance = instance;
    }

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        atHome = false;
        atResource = false;
        ps = GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (instance == null) return;

        if (ps.food <= 90)
        {
            animator.SetBool("Dead", true);
            GameOver.GetInstance().SetActive(true);
            return;
        }

        Transform transform = GetComponent<Transform>();

        float translationX = speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float translationY = speed * Input.GetAxis("Vertical") * Time.deltaTime;

        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Buch", false);
        animator.SetBool("Drop", false);

        if (atHome && ps.inventory > 0)
            animator.SetBool("Drop", true);
        else if (atResource && ps.inventory < ps.maxInventory)
            animator.SetBool("Buch", true);
        else if (Input.GetAxis("Vertical") > 0)
            animator.SetBool("Up", true);
        else if (Input.GetAxis("Vertical") < 0)
            animator.SetBool("Down", true);
        else if(Input.GetAxis("Horizontal") < 0)
            animator.SetBool("Left", true);
        else if (Input.GetAxis("Horizontal") > 0)
            animator.SetBool("Right", true);

        transform.Translate(translationX, translationY, translationY);

        if (atResource && Input.GetButtonDown("Action"))
        {
            string message = "{\"event\":\"activateFlux\"}";
            Manager.PushWebSocket(message);
        }
        if (atHome && Input.GetButtonDown("Action"))
        {
            string message = "{\"event\":\"getRscHome\"}";
            Manager.PushWebSocket(message);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Home")
        {
            atHome = true;
        }
        if (other.tag == "Resource")
        {
            atResource = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Home")
        {
            atHome = false;
        }
        if (other.tag == "Resource")
        {
            atResource = false;
        }
    }
}
