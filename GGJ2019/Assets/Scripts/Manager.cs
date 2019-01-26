using UnityEngine;
using System;
using System.Text;
using System.Threading;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.IO;

public class Manager : MonoBehaviour
{
    public ClientWebSocket clientWebSocket;
    private Task<WebSocketReceiveResult> task;

    // Use this for initialization
    void Start ()
    {
        if (ServerHandler.GetServerHandler().IsUp())
            SetupClient();
        else
            Debug.LogError("Server is not up at game start");
    }
	
	// Update is called once per frame
	void Update ()
    {
		PullWebSocket();
	}

    public async void PullWebSocket()
    {
        ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);

        WebSocketReceiveResult result = null;

        using (var ms = new MemoryStream())
        {
            do
            {
                result = await clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
                ms.Write(buffer.Array, buffer.Offset, result.Count);
            }
            while (!result.EndOfMessage);

            string str = Encoding.UTF8.GetString(buffer.Array);
            Debug.Log(str);
        }
    }

    public async void SetupClient()
    {
        clientWebSocket = new ClientWebSocket();
        Uri uri = new Uri("ws://127.0.0.1:8080");
        await clientWebSocket.ConnectAsync(uri, CancellationToken.None);
        Debug.Log("Connected to server");

        ArraySegment<Byte> msg = new ArraySegment<byte>(
                     Encoding.UTF8.GetBytes("{\"event\":\"new\",\"name\":\"Bob\"}")
                 );
        await clientWebSocket.SendAsync(msg, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    void OnApplicationQuit()
    {
        ServerHandler.GetServerHandler().StopServer();
    }
}
