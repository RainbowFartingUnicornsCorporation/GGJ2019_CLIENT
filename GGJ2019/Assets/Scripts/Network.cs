using UnityEngine;
using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.WebSockets;

public class Network : MonoBehaviour
{
    public ClientWebSocket clientWebSocket;

    // Use this for initialization
    void Start ()
    {
        SetupClient();
    }

    // Create a client and connect to the server port
    public async void SetupClient()
    {
        clientWebSocket = new ClientWebSocket();
        Uri uri = new Uri("ws://127.0.0.1:8080");
        await clientWebSocket.ConnectAsync(uri, CancellationToken.None);
        Debug.Log("Connected to server");

        ArraySegment<Byte> msg = new ArraySegment<byte>(
                     Encoding.UTF8.GetBytes("hello fury from unity")
                 );
        await clientWebSocket.SendAsync(msg, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
