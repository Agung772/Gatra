using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCardGameplay : MonoBehaviour
{
    public bool iniCardPlayer, iniCardEnemy;
    public GameObject[] codeCard;
    public GameObject[] nomorUrutCard;

    int codeCard1, codeCard2, codeCard3, codeCard4, codeCard5;
    private void Awake()
    {


        nomorUrutCard = new GameObject[5];
        if (iniCardPlayer)
        {
            codeCard1 = PlayerPrefs.GetInt("Card1");
            codeCard2 = PlayerPrefs.GetInt("Card2");
            codeCard3 = PlayerPrefs.GetInt("Card3");
            codeCard4 = PlayerPrefs.GetInt("Card4");
            codeCard5 = PlayerPrefs.GetInt("Card5");
            SpawnCard(codeCard1, codeCard2, codeCard3, codeCard4, codeCard5);

            for (int i = 0; i < nomorUrutCard.Length; i++)
            {
                nomorUrutCard[i] = transform.GetChild(i).gameObject;
                nomorUrutCard[i].GetComponent<CardController>().urutanCard = i + 1;
                nomorUrutCard[i].GetComponent<CardController>().iniCardPlayer = true;
            }
        }
        if (iniCardEnemy)
        {
            SpawnCard(Random.Range(1, 13), Random.Range(1, 13), Random.Range(1, 13), Random.Range(1, 13), Random.Range(1, 13));
            for (int i = 0; i < nomorUrutCard.Length; i++)
            {
                nomorUrutCard[i] = transform.GetChild(i).gameObject;
                nomorUrutCard[i].GetComponent<CardController>().urutanCard = i + 1;
                nomorUrutCard[i].GetComponent<CardController>().iniCardPlayer = false;
                nomorUrutCard[i].GetComponent<CardController>().gameObject.tag = "CardEnemy";
            }
        }
    }
    private void Start()
    {


    }
    public void SpawnCard(int card1, int card2, int card3, int card4, int card5)
    {
        if (card1 == 1) Instantiate(codeCard[1], transform);
        else if (card1 == 2) Instantiate(codeCard[2], transform);
        else if (card1 == 3) Instantiate(codeCard[3], transform);
        else if (card1 == 4) Instantiate(codeCard[4], transform);
        else if (card1 == 5) Instantiate(codeCard[5], transform);
        else if (card1 == 6) Instantiate(codeCard[6], transform);
        else if (card1 == 7) Instantiate(codeCard[7], transform);
        else if (card1 == 8) Instantiate(codeCard[8], transform);
        else if (card1 == 9) Instantiate(codeCard[9], transform);
        else if (card1 == 10) Instantiate(codeCard[10], transform);
        else if (card1 == 11) Instantiate(codeCard[11], transform);
        else if (card1 == 12) Instantiate(codeCard[12], transform);
        else if (card1 == 13) Instantiate(codeCard[13], transform);
        else if (card1 == 14) Instantiate(codeCard[14], transform);

        if (card2 == 1) Instantiate(codeCard[1], transform);
        else if (card2 == 2) Instantiate(codeCard[2], transform);
        else if (card2 == 3) Instantiate(codeCard[3], transform);
        else if (card2 == 4) Instantiate(codeCard[4], transform);
        else if (card2 == 5) Instantiate(codeCard[5], transform);
        else if (card2 == 6) Instantiate(codeCard[6], transform);
        else if (card2 == 7) Instantiate(codeCard[7], transform);
        else if (card2 == 8) Instantiate(codeCard[8], transform);
        else if (card2 == 9) Instantiate(codeCard[9], transform);
        else if (card2 == 10) Instantiate(codeCard[10], transform);
        else if (card2 == 11) Instantiate(codeCard[11], transform);
        else if (card2 == 12) Instantiate(codeCard[12], transform);
        else if (card2 == 13) Instantiate(codeCard[13], transform);
        else if (card2 == 14) Instantiate(codeCard[14], transform);

        if (card3 == 1) Instantiate(codeCard[1], transform);
        else if (card3 == 2) Instantiate(codeCard[2], transform);
        else if (card3 == 3) Instantiate(codeCard[3], transform);
        else if (card3 == 4) Instantiate(codeCard[4], transform);
        else if (card3 == 5) Instantiate(codeCard[5], transform);
        else if (card3 == 6) Instantiate(codeCard[6], transform);
        else if (card3 == 7) Instantiate(codeCard[7], transform);
        else if (card3 == 8) Instantiate(codeCard[8], transform);
        else if (card3 == 9) Instantiate(codeCard[9], transform);
        else if (card3 == 10) Instantiate(codeCard[10], transform);
        else if (card3 == 11) Instantiate(codeCard[11], transform);
        else if (card3 == 12) Instantiate(codeCard[12], transform);
        else if (card3 == 13) Instantiate(codeCard[13], transform);
        else if (card3 == 14) Instantiate(codeCard[14], transform);

        if (card4 == 1) Instantiate(codeCard[1], transform);
        else if (card4 == 2) Instantiate(codeCard[2], transform);
        else if (card4 == 3) Instantiate(codeCard[3], transform);
        else if (card4 == 4) Instantiate(codeCard[4], transform);
        else if (card4 == 5) Instantiate(codeCard[5], transform);
        else if (card4 == 6) Instantiate(codeCard[6], transform);
        else if (card4 == 7) Instantiate(codeCard[7], transform);
        else if (card4 == 8) Instantiate(codeCard[8], transform);
        else if (card4 == 9) Instantiate(codeCard[9], transform);
        else if (card4 == 10) Instantiate(codeCard[10], transform);
        else if (card4 == 11) Instantiate(codeCard[11], transform);
        else if (card4 == 12) Instantiate(codeCard[12], transform);
        else if (card4 == 13) Instantiate(codeCard[13], transform);
        else if (card4 == 14) Instantiate(codeCard[14], transform);

        if (card5 == 1) Instantiate(codeCard[1], transform);
        else if (card5 == 2) Instantiate(codeCard[2], transform);
        else if (card5 == 3) Instantiate(codeCard[3], transform);
        else if (card5 == 4) Instantiate(codeCard[4], transform);
        else if (card5 == 5) Instantiate(codeCard[5], transform);
        else if (card5 == 6) Instantiate(codeCard[6], transform);
        else if (card5 == 7) Instantiate(codeCard[7], transform);
        else if (card5 == 8) Instantiate(codeCard[8], transform);
        else if (card5 == 9) Instantiate(codeCard[9], transform);
        else if (card5 == 10) Instantiate(codeCard[10], transform);
        else if (card5 == 11) Instantiate(codeCard[11], transform);
        else if (card5 == 12) Instantiate(codeCard[12], transform);
        else if (card5 == 13) Instantiate(codeCard[13], transform);
        else if (card5 == 14) Instantiate(codeCard[14], transform);
    }
}
