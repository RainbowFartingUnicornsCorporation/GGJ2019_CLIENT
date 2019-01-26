using UnityEngine;
using System;
using System.Text;
using System.Threading;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public ClientWebSocket clientWebSocket;
    private Task<WebSocketReceiveResult> task;

    // Use this for initialization
    void Start()
    {
        if (ServerHandler.GetServerHandler().IsUp())
            SetupClient();
        else
            Debug.LogError("Server is not up at game start");
    }

    // Update is called once per frame
    void Update()
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

            using (Stream stream = new MemoryStream(buffer.Array))
            {
                var serializer = new DataContractJsonSerializer(typeof(GameState));
                Debug.Log("Deserialization start");
                GameState gameState = (GameState)serializer.ReadObject(stream);
                Debug.Log("Deserialization ok");
                gameState.Instantiate();
            }
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

[DataContract]
class GameState
{
    [DataMember(Name = "ressources")] public IList<Resource> Ressources { get; set; }
    [DataMember(Name = "player")] public Player Player { get; set; }
    [DataMember(Name = "date")] public Home Home { get; set; }

    public void Instantiate()
    {
        foreach (Resource res in Ressources)
        {
            res.Instantiate();
        }
        Player.Instantiate();
        Home.Instantiate();
    }
}

[DataContract]
class Home
{
    [DataMember(Name = "type")] public int Type { get; set; }
    [DataMember(Name = "food")] public int Food { get; set; }
    [DataMember(Name = "ressources")] public int Resource { get; set; }
    [DataMember(Name = "population")] public int Population { get; set; }
    [DataMember(Name = "foodGoal")] public int FoodGoal { get; set; }
    [DataMember(Name = "reservePop")] public int ReservePop { get; set; }

    public void Instantiate()
    {
        //Debug.Log(this);
    }
}

[DataContract]
class Resource
{
    [DataMember(Name = "id")] public int Id { get; set; }
    [DataMember(Name = "type")] public int Type { get; set; }
    [DataMember(Name = "nbWorker")] public int NbWorker { get; set; }
    [DataMember(Name = "posX")] public float PosX { get; set; }
    [DataMember(Name = "posY")] public float PosY { get; set; }
    [DataMember(Name = "size")] public int Size { get; set; }
    [DataMember(Name = "sizeMax")] public int SizeMax { get; set; }

    public void Instantiate()
    {
        //Debug.Log(this);
    }
}

[DataContract]
public class Player
{
    [DataMember(Name = "type")] public int Type { get; set; }
    [DataMember(Name = "name")] public string Name { get; set; }
    [DataMember(Name = "posX")] public float PosX { get; set; }
    [DataMember(Name = "posY")] public float PosY { get; set; }
    [DataMember(Name = "food")] public int Food { get; set; }
    [DataMember(Name = "inventory")] public int Inventory { get; set; }
    [DataMember(Name = "maxFood")] public int MaxFood { get; set; }
    [DataMember(Name = "maxInventory")] public int MaxInventory { get; set; }

    public void Instantiate()
    {
        //Debug.Log(this);
    }
}