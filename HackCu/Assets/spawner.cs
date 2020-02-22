using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    string[] deck = new string[52];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < deck.Length; i++)
        {
            deck[i] = i.ToString();
        }
        reshuffle(deck);
        Debug.Log(deck[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void reshuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++ )
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
