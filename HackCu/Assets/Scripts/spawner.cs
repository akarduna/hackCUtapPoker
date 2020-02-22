using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{
    int[] deck = new int[52];
    public GameObject[] cards = new GameObject[52];
    // Start is called before the first frame update
    public List<int> playerCards = new List<int>();
    float offset = 0.15F;
    bool flippedCard = false;
    int cardCount = 0;
    public List<int> dealerCards = new List<int>();
    GameObject needToFlip;
    void Start()
    {
        for(int i = 0; i < deck.Length; i++)
        {
            deck[i] = i+1;
        }
        reshuffle(deck);
        playerCards.Add(deck[0]);
        GameObject obj = Instantiate(cards[deck[0]-1], transform.position + new Vector3(offset*(playerCards.Count-1), 0, 0),  Quaternion.Euler(0,0,0));
        obj.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        dealerCards.Add(deck[1]);
        needToFlip = Instantiate(cards[deck[1]-1], transform.position + new Vector3(0, 0, .4F),  Quaternion.Euler(180,0,0));
        needToFlip.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        playerCards.Add(deck[2]);
        obj = Instantiate(cards[deck[2]-1], transform.position + new Vector3(offset*(playerCards.Count-1), 0, 0),  Quaternion.Euler(0,0,0));
        obj.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        dealerCards.Add(deck[3]);
        obj = Instantiate(cards[deck[3]-1], transform.position + new Vector3(.15F, 0, .4F),  Quaternion.Euler(0,0,0));
        obj.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        cardCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !flippedCard)
        {
            needToFlip.transform.Rotate(180,0,0);
            flippedCard = true;
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            playerCards.Add(deck[cardCount]);
            GameObject obj = Instantiate(cards[deck[cardCount]-1], transform.position + new Vector3(offset*(playerCards.Count-1), 0, 0),  Quaternion.Euler(0,0,0));
            obj.transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
            cardCount++;
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
