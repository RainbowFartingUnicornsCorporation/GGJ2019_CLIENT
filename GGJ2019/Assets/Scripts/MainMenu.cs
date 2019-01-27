using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public bool IsDebug = false;

    public void StartAloneButtonPressed()
    {
        Debug.Log("Button alone was pressed!");
        ServerHandler.GetServerHandler().StartServer(IsDebug);
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
    }

    public void StartHostingButtonPressed()
    {
        Debug.Log("Button host was pressed!");
        ServerHandler.GetServerHandler().StartServer(IsDebug);
    }

    public void JoinServerButtonPressed()
    {
        Debug.Log("Button join was pressed!");
    }

    void OnApplicationQuit()
    {
        ServerHandler.GetServerHandler().StopServer();
    }
}
