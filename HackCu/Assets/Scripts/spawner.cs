using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{
    int[] deck = new int[52];
    public GameObject[] cards = new GameObject[52];
    // Start is called before the first frame update
    public List<GameObject> playerCards = new List<GameObject>();
    public int playerVal = 0;
    float offset = 0.075F;
    int flippedCard = 0;
    void Start()
    {
        for(int i = 0; i < deck.Length; i++)
        {
            deck[i] = i;
        }
        reshuffle(deck);
        for(int i = 0; i < 2; i++)
        {
            playerVal += deck[i]%13;
            playerCards.Add(Instantiate(cards[deck[i]], transform.position + new Vector3(offset*playerCards.Count, 0, 0),  Quaternion.Euler(180,0,0)));
        }
    }
       

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && flippedCard<playerCards.Count)
        {
            playerCards[flippedCard].transform.Rotate(180,0,0);
            flippedCard++;
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
