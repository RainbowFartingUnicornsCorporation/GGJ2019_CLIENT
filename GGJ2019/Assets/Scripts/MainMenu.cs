using UnityEngine;

public class MainMenu : MonoBehaviour {
    public void StartAloneButtonPressed()
    {
        Debug.Log("Button alone was pressed!");
        ServerHandler.GetServerHandler().StartServer();
    }

    public void StartHostingButtonPressed()
    {
        Debug.Log("Button host was pressed!");
        ServerHandler.GetServerHandler().StartServer();
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
