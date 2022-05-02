using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordInput : MonoBehaviour
{
    private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is run each time the value of the input field is changed
    private void OnValueChange(string value)
    {
        // if incorrect character -> damage
        // if character removed -> do nothing
        // if correct answer (string matches) game won
    }
}
