using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    int[] deck = new int[52];
    public GameObject[] cards = new GameObject[52];
    // Start is called before the first frame update
    GameObject card;
    void Start()
    {
        for(int i = 0; i < deck.Length; i++)
        {
            deck[i] = i;
        }
        reshuffle(deck);
        card = Instantiate(cards[deck[0]], transform.position,  Quaternion.Euler(180,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            card.transform.Rotate(180,0,0);
        }
    }
    void reshuffle(int[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++ )
        {
            int tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
