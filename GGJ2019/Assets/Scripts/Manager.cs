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

	public GameObject Home;
	public GameObject Player;
	public GameObject Flux;
	public GameObject Ressource;
	public Camera mainCamera;

	private GameObject player;
	private GameObject home;
	private List<GameObject> flux;
	private List<GameObject> ressources;

	private bool initGame = false;

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
            RootObject obj = JsonUtility.FromJson<RootObject>(str);
 
			if (initGame == false) { 

				initGame = true;
			
				// Init home
				home = Instantiate (Home, new Vector3 (0, 0, 0), transform.rotation) as GameObject;
				home.GetComponent<HomeScript> ().updateHome (obj.home);

				// Init player
				player = Instantiate (Player, new Vector3 (obj.player.posX, obj.player.posY, 0), transform.rotation) as GameObject;
				player.GetComponent<PlayerScript> ().updatePlayer (obj.player);
				player.GetComponent<PlayerScript> ().mainCamera = mainCamera;
                PlayerController playerController = player.AddComponent<PlayerController>();
                playerController.SetPlayer(player);
			

                // Init Ressource
                ressources = new List<GameObject>();
				foreach (Ressource rsc in obj.ressources) {
					var ressource = Instantiate (Ressource, new Vector3 (rsc.posX, rsc.posY, 0), transform.rotation) as GameObject;
					Debug.Log (ressource);
					ressource.GetComponent<RessourceScript> ().updateRessource (rsc);
					ressources.Add (ressource);
				}


				// Init Flux
				flux = new List<GameObject>();

			} else {
				// update Home
				home.GetComponent<HomeScript> ().updateHome (obj.home);
				// update Player
				player.GetComponent<PlayerScript> ().updatePlayer (obj.player);
				// update Ressource
				foreach (Ressource rscData in obj.ressources){
					foreach (GameObject rsc in ressources){
						if (rsc.GetComponent<RessourceScript> ().getId () == rscData.id) {
							rsc.GetComponent<RessourceScript> ().updateRessource (rscData);
						}
					}
				}
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

[System.Serializable]
public class Ressource
{
	public int id;
	public int type;
	public int nbWorker;
	public int posX;
	public int posY;
	public int size;
	public int sizeMax;
}

[System.Serializable]
public class Player
{
    public int type;
	public string name;
    public int posX;
	public int posY;
	public int food;
	public int inventory;
	public int maxFood;
	public int maxInventory;
}

[System.Serializable]
public class Home
{
	public int type;
	public int food;
	public int ressources;
	public int population;
	public int foodGoal;
	public int reservePop;
}

[System.Serializable]
public class RootObject
{
    public int test;
    public List<Ressource> ressources;
    public Player player;
    public Home home;
}