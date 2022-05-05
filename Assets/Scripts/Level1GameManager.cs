using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Level1GameManager : NetworkBehaviour
{
    public NetworkVariable<int> health = new(100); // shorthand for 'new NetworkVariable<int>(100)'

    // https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    // public - globally accessible
    // static - shared by all instances, therefore can be accessed without a reference to an instance
    // { get; private set; } - prevents other scripts from setting this
    public static Level1GameManager Instance { get; private set; } // used to refer to the singleton instance

    private void Awake()
    {
        // Sets the instance variable. Deletes this instance if the variable is already set (so there can be only one instance).
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public int LoseHealth(int damage)
    {
        health.Value = health.Value - damage;
        if (health.Value <= 0)
        {
            LoseGame();
        }
        return health.Value;
    }

    public void LoseGame()
    {
        Debug.Log("GAME OVER!");
    }

    public void WinGame()
    {
        Debug.Log("YOU WIN!");
    }
}
