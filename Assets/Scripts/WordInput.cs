using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInput : MonoBehaviour
{
    private TMP_InputField inputField;
    private string password = "password";
    private string lastValue;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        lastValue = inputField.text;
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is run each time the value of the input field is changed
    private void OnValueChanged(string value)
    {
        if (value.Length >= lastValue.Length) // if a character is removed -> do nothing
        {
            for (int i = 0; i < value.Length; i++) // go through every character
            {
                if (value[i] != password[i]) // if an incorrect character is found:
                {
                    // TO DO: sound
                    Level1GameManager.Instance.LoseHealth(10);
                    break; // stop checking
                }
            }

            if (value == password)
            {
                // TO DO: free player 2
                gameObject.SetActive(false);
                Level1GameManager.Instance.WinGame();
            }
        }
        lastValue = value;
    }
}
