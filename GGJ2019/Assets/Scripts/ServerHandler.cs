﻿using UnityEngine;

public class ServerHandler
{
    private static ServerHandler serverHandler;

    public static ServerHandler GetServerHandler()
    {
        if (serverHandler == null)
        {
            serverHandler = new ServerHandler();
        }
        return serverHandler;
    }

    private System.Diagnostics.Process serverProcess;

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
        if (serverProcess == null || serverProcess.HasExited) return; 
        serverProcess.Kill();
        Debug.Log("Server stopped");
    }

    public bool IsUp()
    {
        return serverProcess != null && !serverProcess.HasExited;
    }
}
