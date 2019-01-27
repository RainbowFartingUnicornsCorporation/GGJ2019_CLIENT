using UnityEngine;

public class Background : MonoBehaviour {

    private static bool copy = true;

    private SpriteRenderer[][] sprites;

	void Start ()
    {
        if (!copy) return;

        copy = false;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        for (int i = -5; i <= 5; i++)
            for (int j = -3; i <= 3; j++)
            {
                SpriteRenderer obj = (SpriteRenderer) Object.Instantiate(sprite);
                obj.transform.Translate(new Vector3(obj.size.x / 2 + i * obj.size.x, obj.size.y / 2 + j * obj.size.y, 0));
            }
    }
}
