using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

// https://github.com/JaniSeppala/OGP-Lectures

// Example script for manually spawning the player when a client connects to the online session
// Remember to remove the player prefab from the Network Manager component in the scene if you use this script
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player1Prefab; // The prefab that we spawn to represent the player
    [SerializeField] GameObject player2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        // Run the OnServerStarted() method when the server starts
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
    }

    private void OnServerStarted()
    {
        // Only server is allowed to spawn objects into the online session
        if (NetworkManager.Singleton.IsServer)
        {
            // Load the Game Scene as soon as the server starts
            NetworkManager.Singleton.SceneManager.LoadScene("Level1", UnityEngine.SceneManagement.LoadSceneMode.Single);

            // If we started as a host, we also have to spawn a player object for the host
            if (NetworkManager.Singleton.IsHost)
            {
                // We want to spawn the player character for the host only when the Game Scene has completed loading so we start listening for the OnLoadComplete event
                NetworkManager.Singleton.SceneManager.OnLoadComplete += OnLoadComplete;
            }
            // Run the OnClientConnectCallback() method each time a client connects the online session. This event is run on the server and on the client that connects
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
        }
    }

    // This is run each time a client has finished loading a scene on the server. It is also run on the local client when the local client finishes loading an online scene
    private void OnLoadComplete(ulong clientId, string sceneName, UnityEngine.SceneManagement.LoadSceneMode loadSceneMode)
    {
        // When the scene is loaded on the host, spawn the player character for the host
        if (NetworkManager.Singleton.IsHost && clientId == NetworkManager.Singleton.LocalClientId && sceneName == "Level1")
        {
            GameObject go = Instantiate(player1Prefab); // Instantiate the player prefab locally on the server
            NetworkObject no = go.GetComponent<NetworkObject>(); // Get a reference to the instantiated objects NetworkObject component 
            no.SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId); // Spawn the object into the online session as the player object of the local player (host)
        }
    }

    // Spawns a player object for the client whose ID is 
    private void OnClientConnectedCallback(ulong clientID)
    {
        // Only the server is allowed to spawn objects into the online session
        if (NetworkManager.Singleton.IsServer)
        {
            GameObject go = Instantiate(player2Prefab); // Instantiate the player prefab locally on the server
            NetworkObject no = go.GetComponent<NetworkObject>(); // Get a reference to the instantiated objects NetworkObject component 
            no.SpawnAsPlayerObject(clientID); // Spawn the object into the online session as the player object of the client that just connected
        }
    }
}
