using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public bool IsDebug = false;
    public GameObject[] ObjectsToDestroy;
    public GameObject CanvasToEnable;
    public Text IpText;

    public void StartAloneButtonPressed()
    {
        Debug.Log("Button alone was pressed!");
        ServerHandler.GetServerHandler().StartServer(IsDebug);
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
    }

    public void StartHostingButtonPressed()
    {
        Debug.Log("Button quit was pressed!");
        Application.Quit();
    }

    public void JoinServerButtonPressed()
    {
        foreach (GameObject go in ObjectsToDestroy)
        {
            Destroy(go);
        }
        CanvasToEnable.SetActive(true);
    }

    public void JoinButtonPressed()
    {
        ServerHandler.Ip = IpText.text;
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
    }

void OnApplicationQuit()
    {
        ServerHandler.GetServerHandler().StopServer();
    }
}
