using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Instantiate(playerPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
