using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class WordInputUILoader : MonoBehaviour
{
    [SerializeField] private GameObject inputUIPrefab;
    // private GameObject player1; // GameObject.FindGameObjectsWithTag("Player 1");
    private GameObject inputUIGO;
    private TMP_InputField inputField;

    void Start()
    {
        inputUIGO = Instantiate(inputUIPrefab); // load UI
        inputField = inputUIGO.GetComponentInChildren<TMP_InputField>(true);
        inputUIGO.SetActive(false);
    }

    void Update()
    {
        // TO DO: hide input UI if player 1 presses esc
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player 1") return; // exit the method if collider is not player 1

        // TO DO:
        // disable movement
        // don't activate inputfield until player 1 has stopped or released wasd

        inputUIGO.SetActive(true); // show input ui
        inputField.ActivateInputField(); // enable input focus so you can start typing
    }

    private void OnTriggerExit(Collider other)
    {
        inputUIGO.SetActive(false); // hide input ui
    }
}
