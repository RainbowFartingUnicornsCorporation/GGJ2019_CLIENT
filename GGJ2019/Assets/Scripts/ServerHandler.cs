using UnityEngine;

public class ServerHandler
{
    private static ServerHandler serverHandler;
    private System.Diagnostics.Process serverProcess;

    public static ServerHandler GetServerHandler()
    {
        if (serverHandler == null)
        {
            Debug.Log("New server handler");
            serverHandler = new ServerHandler();
        }
        return serverHandler;
    }
    
    public void StartServer()
    {
        if (serverProcess != null) return;
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "server.exe");
        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(filePath);
        info.CreateNoWindow = true;
        info.UseShellExecute = false;
        serverProcess = System.Diagnostics.Process.Start(info);
        Debug.Log("Server started");
    }

    public void StopServer()
    {
        if (serverProcess == null || serverProcess.HasExited)
        {
            Debug.Log("No need to stop server");
            return;
        }
        else
        {
            serverProcess.Kill();
            Debug.Log("Server stopped");
        }
    }

    public bool IsUp()
    {
        return serverProcess != null && !serverProcess.HasExited;
    }
}
