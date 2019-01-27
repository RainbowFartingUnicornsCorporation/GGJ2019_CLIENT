using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private static GameObject instance;
    private Sprite[] spritesAsset;
    private Image image;
    private int counter;

    public static GameObject GetInstance()
    {
        return instance;
    }

    void Start()
    {
        image = GetComponent<Image>();
        spritesAsset = new Sprite[2];
        spritesAsset[0] = Resources.Load<Sprite>("Sprites/GameOver_0");
        spritesAsset[1] = Resources.Load<Sprite>("Sprites/GameOver_1");
        counter = 0;
        GameObject go = GetComponentInParent<Canvas>().gameObject;
        instance = go;
        go.SetActive(false);
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
