using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// To do: method that reveals correct letters (slowly or randomly or one-by-one, etc.)

public class TextEffect : MonoBehaviour
{
    public string text; // The correct word that players try to solve. This is public for now, because other scripts will set/get this.
    private int length;
    private TextMeshPro tmp;

    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        length = text.Length;

        // generates a random string with the same length as the answer
        string randomText = "";
        for (int i = 0; i < length; i++) {
            string s = ((char)Random.Range(0x41, 0x5A)).ToString(); // random uppercase letter
            randomText = randomText.Insert(i, s);
            randomText.Insert(i, s);
        }
        tmp.text = randomText;
    }

    void Update()
    {
        // Replaces a character at a random position with a new random letter.
        int i = Random.Range(0, length); // index of the random character to be replaced
        string s = ((char) Random.Range(0x41, 0x5A)).ToString(); // random uppercase letter
        tmp.text = tmp.text.Insert(i, s);
        tmp.text = tmp.text.Remove(i + 1, 1);
    }
}
