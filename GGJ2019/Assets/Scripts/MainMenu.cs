using UnityEngine;

public class MainMenu : MonoBehaviour {
    public ServerHandler serverHandler;

    public void StartAloneButtonPressed()
    {
        Debug.Log("Button alone was pressed!");
        serverHandler.StartServer();
    }

    public void StartHostingButtonPressed()
    {
        Debug.Log("Button host was pressed!");
        serverHandler.StartServer();
    }

    public void JoinServerButtonPressed()
    {
        Debug.Log("Button join was pressed!");
    }
}
