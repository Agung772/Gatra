using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CardController : MonoBehaviour
{
    public bool playGame;
    public int urutanCard;
    public bool iniCardPlayer;
    public float api, air, tanah, udara;
    public TextMeshProUGUI apiText, airText, tanahText, udaraText;
    public Animator animator;
    public Outline outline;
    public BattleManager battleManager;
    public string conditionCard;

    private void Awake()
    {
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }
    private void Start()
    {
        StartCoroutine(startCoroutine());
        IEnumerator startCoroutine()
        {
            apiText.text = "" + api;
            airText.text = "" + air;
            tanahText.text = "" + tanah;
            udaraText.text = "" + udara;
            yield return new WaitForSeconds(2);
            CardLobby();
        }
    }
    private void OnMouseDown()
    {
        if (iniCardPlayer && playGame)
        {
            ClickCard();

            AudioManager.instance.ButtonUISfx();
        }

    }

    private void OnMouseEnter()
    {
        if (iniCardPlayer && playGame) outline.enabled = true;
    }
    private void OnMouseExit()
    {
        if (iniCardPlayer && playGame) outline.enabled = false;
    }

    public void ClickCard()
    {
        if (conditionCard == "View")
        {
            if (urutanCard == 1)
            {
                animator.SetTrigger("FarLeft");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 2)
            {
                animator.SetTrigger("Left");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 3)
            {
                animator.SetTrigger("Mid");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 4)
            {
                animator.SetTrigger("Right");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 5)
            {
                animator.SetTrigger("FarRight");
                conditionCard = "Lobby";
            }
        }

        else if (conditionCard == "Lobby")
        {
            battleManager.BackCard();

            animator.SetTrigger("View");
            conditionCard = "View";
        }

    }
    public void TransferElement()
    {
        if (conditionCard == "View")
        {
            conditionCard = "Battle";
            

            if (iniCardPlayer)
            {
                animator.SetTrigger("Battle");
                battleManager.ElementPlayer(api, air, tanah, udara);
            }
            else if (!iniCardPlayer)
            {
                animator.SetTrigger("BattleE");
                battleManager.ElementEnemy(api, air, tanah, udara);
            }

        }
        
    }
    void CardLobby()
    {
        if (urutanCard == 1)
        {
            animator.SetTrigger("FarLeft");
            conditionCard = "Lobby";
        }
        else if (urutanCard == 2)
        {
            animator.SetTrigger("Left");
            conditionCard = "Lobby";
        }
        else if (urutanCard == 3)
        {
            animator.SetTrigger("Mid");
            conditionCard = "Lobby";
        }
        else if (urutanCard == 4)
        {
            animator.SetTrigger("Right");
            conditionCard = "Lobby";
        }
        else if (urutanCard == 5)
        {
            animator.SetTrigger("FarRight");
            conditionCard = "Lobby";
        }
    }

    public void DestroyCard()
    {
        if (conditionCard == "Battle")
        {
            Destroy(gameObject);
        }
    }

    public void BackLobby()
    {
        if (conditionCard == "Battle")
        {
            if (urutanCard == 1)
            {
                animator.SetTrigger("FarLeft");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 2)
            {
                animator.SetTrigger("Left");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 3)
            {
                animator.SetTrigger("Mid");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 4)
            {
                animator.SetTrigger("Right");
                conditionCard = "Lobby";
            }
            else if (urutanCard == 5)
            {
                animator.SetTrigger("FarRight");
                conditionCard = "Lobby";
            }
        }
    }

}
