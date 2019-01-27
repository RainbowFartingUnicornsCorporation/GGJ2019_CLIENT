using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour {
    private Sprite[] spritesAsset;
    private Image image;
    private int counter;

    void Start()
    {
        image = GetComponent<Image>();
        spritesAsset = new Sprite[2];
        spritesAsset[0] = Resources.Load<Sprite>("Sprites/Title_0");
        spritesAsset[1] = Resources.Load<Sprite>("Sprites/Title_1");
        counter = 0;
    }

    void Update()
    {
        counter++;
        counter %= 40;
        if (counter < 20)
            image.sprite = spritesAsset[0];
        else
            image.sprite = spritesAsset[1];
    }
}
