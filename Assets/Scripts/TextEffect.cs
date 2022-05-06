using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffect : MonoBehaviour
{
    public string answer; // The correct word that players try to solve. This is public for now, because other scripts will set/get this.
    private int length; // length of answer and randomWord
    private TextMeshPro tmp;
    private char[] randomWord;
    private bool revealAnswer = false;

    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        length = answer.Length;

        // generates a random character array with the same length as the answer
        randomWord = new char[length];
        for (int i = 0; i < length; i++) {
            char c = ((char)Random.Range(0x41, 0x5A)); // random uppercase letter
            randomWord[i] = c;
        }
        tmp.text = randomWord.ToString();

        StartCoroutine("ChangeRandomLetter");
        Level1GameManager.Instance.health.OnValueChanged += OnValueChangedTextEffect;
    }

    private void OnValueChangedTextEffect(int previous, int current)
    {
        StartCoroutine("RevealAnswer");
    }

    private IEnumerator ChangeRandomLetter()
    {
        // Replaces a character at a random position with a new random letter.
        int i = Random.Range(0, length); // index of the random character to be replaced
        char c;
        if (revealAnswer) c = answer[i]; // correct character at the index
        else { c = ((char)Random.Range(0x41, 0x5A)); } // random uppercase letter
        randomWord[i] = c;

        // parse output
        string output = "<mspace=1>"; // monospace
        if (revealAnswer) // add red color to correct letters if player2 is being electrocuted
        {
            for (int j = 0; j < length; j++)
            {
                if (randomWord[j] == answer[j]) output += "<color=#FF0000>";
                output += randomWord[j];
                if (randomWord[j] == answer[j]) output += "</color>";
            }
        }
        else
        {
            output += new string(randomWord); // convert char[] randomWord to string and add to string output
        }
        output += "</mspace>"; // monospace

        tmp.text = output;

        yield return new WaitForSeconds(0.05f);
        StartCoroutine("ChangeRandomLetter");
    }

    private IEnumerator RevealAnswer()
    {
        revealAnswer = true;
        yield return new WaitForSeconds(0.25f);
        revealAnswer = false;

    }
}
