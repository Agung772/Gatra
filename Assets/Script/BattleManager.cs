using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public BidakController bidakPlayer, bidakEnemy;
    public AnimasiCamera animasiCam;
    public BotController botController;
    public GameObject allButton;
    public GameObject[] cardPlayer;
    public CardController[] cardControllerP;
    public GameObject[] cardEnemy;
    public CardController[] cardControllerE;
    public float apiP, airP, tanahP, udaraP;
    public float apiE, airE, tanahE, udaraE;
    public float totalAttckP, totalAttackE;
    public GameObject skill, animasiSkill;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        FindCardPlayer();
        FindCardEnemy();

        botController.RandomElement();

    }

    bool checkView;
    void CheckView()
    {
        for (int i = 0; i < cardControllerP.Length; i++)
        {
            if (cardControllerP[i].conditionCard == "View")
            {
                checkView = true;
            }
        }
    }
    public void BattleCard()
    {
        CheckView();
        //Card battle
        if (checkView)
        {
            checkView = false;

            StartCoroutine(StartBattleCoroutine());
            IEnumerator StartBattleCoroutine()
            {
                allButton.SetActive(false);
                animasiCam.BattleCam();

                //Player
                for (int i = 0; i < cardPlayer.Length; i++)
                {
                    if (cardControllerP[i] != null)
                    {
                        cardControllerP[i].TransferElement();
                    }
                }
                RandomCardEnemy();
                yield return new WaitForSeconds(0.5f);
                //Random Enemy
                cardControllerE[(int)randomFloat].conditionCard = "View";
                for (int i = 0; i < cardEnemy.Length; i++)
                {
                    if (cardControllerE[i] != null)
                    {
                        cardControllerE[i].TransferElement();
                    }
                }

                yield return new WaitForSeconds(3);
                if (botController.codeElement == 1)
                {
                    totalAttckP = apiP;
                    totalAttackE = apiE;

                    if (apiP > apiE)
                    {
                        botController.elementText.text = "Player Win";
                        yield return new WaitForSeconds(2);
                        //Skill
                        ChoiceSkill(true, true);
                    }
                    else if (apiP < apiE)
                    {
                        botController.elementText.text = "Player Lose";
                        yield return new WaitForSeconds(2);
                        PlayerLose();
                    }
                    else if (apiP == apiE)
                    {
                        botController.elementText.text = "Draw";
                        yield return new WaitForSeconds(2);
                        Draw();
                    }
                }
                else if (botController.codeElement == 2)
                {
                    totalAttckP = airP;
                    totalAttackE = airE;

                    if (airP > airE)
                    {
                        botController.elementText.text = "Player Win";
                        yield return new WaitForSeconds(2);
                        //Skill
                        ChoiceSkill(true, true);
                    }
                    else if (airP < airE)
                    {
                        botController.elementText.text = "Player Lose";
                        yield return new WaitForSeconds(2);
                        PlayerLose();

                    }
                    else if (airP == airE)
                    {
                        botController.elementText.text = "Draw";
                        yield return new WaitForSeconds(2);
                        Draw();
                    }
                }
                else if (botController.codeElement == 3)
                {
                    totalAttckP = tanahP;
                    totalAttackE = tanahE;

                    if (tanahP > tanahE)
                    {
                        botController.elementText.text = "Player Win";
                        yield return new WaitForSeconds(2);
                        //Skill
                        ChoiceSkill(true, true);
                    }
                    else if (tanahP < tanahE)
                    {
                        botController.elementText.text = "Player Lose";
                        yield return new WaitForSeconds(2);
                        PlayerLose();

                    }
                    else if (tanahP == tanahE)
                    {
                        botController.elementText.text = "Draw";
                        yield return new WaitForSeconds(2);
                        Draw();
                    }
                }
                else if (botController.codeElement == 4)
                {
                    totalAttckP = udaraP;
                    totalAttackE = udaraE;

                    if (udaraP > udaraE)
                    {
                        botController.elementText.text = "Player Win";
                        yield return new WaitForSeconds(2);
                        //Skill
                        ChoiceSkill(true, true);

                    }
                    else if (udaraP < udaraE)
                    {
                        botController.elementText.text = "Player Lose";
                        yield return new WaitForSeconds(2);
                        PlayerLose();
                    }
                    else if (udaraP == udaraE)
                    {
                        botController.elementText.text = "Draw";
                        yield return new WaitForSeconds(2);
                        Draw();
                    }
                }
            }
        }

        //Gak ada yang dibattlekan
        else if (!checkView)
        {
            print("Pilih card untuk dibattlekan");
        }

        AudioManager.instance.ButtonUISfx();

    }
    public void ElementPlayer(float api, float air, float tanah, float udara)
    {
        apiP = api;
        airP = air;
        tanahP = tanah;
        udaraP = udara;
    }

    public void ElementEnemy(float api, float air, float tanah, float udara)
    {
        apiE = api;
        airE = air;
        tanahE = tanah;
        udaraE = udara; 
    }

    public float randomFloat, maxRandom;
    public bool[] randomBool = new bool[5];
    void RandomCardEnemy()
    {
        
        randomFloat = Random.Range(0, 5);
        if (randomFloat == 0 && !randomBool[0])
        {
            randomBool[0] = true;
            MaxRandom();
        }
        else if (randomFloat == 1 && !randomBool[1])
        {
            randomBool[1] = true;
            MaxRandom();
        }
        else if (randomFloat == 2 && !randomBool[2])
        {
            randomBool[2] = true;
            MaxRandom();
        }
        else if (randomFloat == 3 && !randomBool[3])
        {
            randomBool[3] = true;
            MaxRandom();
        }
        else if (randomFloat == 4 && !randomBool[4])
        {
            randomBool[4] = true;
            MaxRandom();
        }
        else
        {
            RandomCardEnemy();
        }


    }
    void MaxRandom()
    {
        maxRandom++;
        if (maxRandom == 3)
        {
            maxRandom = 0;
            for (int i = 0; i < randomBool.Length; i++)
            {
                randomBool[i] = false;
            }
        }
    }
    void FindCardPlayer()
    {
        cardPlayer = GameObject.FindGameObjectsWithTag("CardPlayer");
        cardControllerP = new CardController[cardPlayer.Length];
        for (int i = 0; i < cardPlayer.Length; i++)
        {
            cardControllerP[i] = cardPlayer[i].GetComponent<CardController>();
        }
    }
    void FindCardEnemy()
    {
        cardEnemy = GameObject.FindGameObjectsWithTag("CardEnemy");
        cardControllerE = new CardController[cardEnemy.Length];
        for (int i = 0; i < cardEnemy.Length; i++)
        {
            cardControllerE[i] = cardEnemy[i].GetComponent<CardController>();
        }
    }
    public void BackCard()
    {
        
        for (int i = 0; i < cardPlayer.Length; i++)
        {
            if (cardPlayer[i] != null)
            {
                if (cardPlayer[i].GetComponent<CardController>().conditionCard == "View")
                {
                    cardPlayer[i].GetComponent<CardController>().ClickCard();
                    print("Back");
                }
            }

        }
    }

    void BackLobby()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            //BackLobbyCard
            yield return new WaitForSeconds(3);
            for (int i = 0; i < cardPlayer.Length; i++)
            {
                if (cardControllerP[i] != null)
                {
                    cardControllerP[i].BackLobby();
                }
            }
            for (int i = 0; i < cardEnemy.Length; i++)
            {
                if (cardControllerE[i] != null)
                {
                    cardControllerE[i].BackLobby();
                }
            }

            //Text
            botController.elementText.text = "";
            //Cam
            animasiCam.ViewCam();
            //Bot
            allButton.SetActive(true);
            botController.RandomElement();
        }
    }

    //Efek Skill
    //1. Skill Bakar
    //2. Skill criticall damage
    //3. Skill penambahan darah sebanyak 20%
    //4. Shield
    //5. Jalan 2×
    public void AttackPlayer(int efekSkill)
    {
        AnimasiSkill(efekSkill);
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1.5f);
            if (efekSkill == 0)
            {
                bidakEnemy.Attack(totalAttckP);
            }
            else if (efekSkill == 1)
            {
                bidakEnemy.Attack(totalAttckP);
                bidakEnemy.SkillBakar();
            }
            else if (efekSkill == 2)
            {
                bidakEnemy.Critical(totalAttckP + totalAttckP * 1.4f);
            }
            else if (efekSkill == 3)
            {
                bidakEnemy.Attack(totalAttckP);
                bidakPlayer.HealHP(bidakPlayer.maxHpBidak / 8);
            }
            else if (efekSkill == 4)
            {
                bidakEnemy.Attack(totalAttckP);
                bidakPlayer.Shield();
            }
            else if (efekSkill == 5)
            {
                bidakEnemy.Jalan2Kali(totalAttckP);
            }

            BackLobby();
        }



    }
    public void AttackEnemy(int efekSkill)
    {
        AnimasiSkill(efekSkill);
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1.5f);
            if (efekSkill == 0)
            {
                bidakPlayer.Attack(totalAttackE);
            }
            else if (efekSkill == 1)
            {
                bidakPlayer.Attack(totalAttackE);
                bidakPlayer.SkillBakar();
            }
            else if (efekSkill == 2)
            {
                bidakPlayer.Critical(totalAttackE + totalAttackE * 1.4f);
            }
            else if (efekSkill == 3)
            {
                bidakPlayer.Attack(totalAttackE);
                bidakEnemy.HealHP(bidakPlayer.maxHpBidak / 8);
            }
            else if (efekSkill == 4)
            {
                bidakPlayer.Attack(totalAttackE);
                bidakEnemy.Shield();
            }
            else if (efekSkill == 5)
            {
                bidakPlayer.Jalan2Kali(totalAttackE);
            }

            BackLobby();

        }


    }

    void ChoiceSkill(bool parameter, bool player)
    {
        if (parameter && player)
        {
            GameManager.instance.choiceSkill.SetActive(true);
            Interactable(player);
        }
        else if (!parameter && player)
        {
            GameManager.instance.choiceSkill.SetActive(false);
            Interactable(player);
        }
        else if (parameter && !player)
        {
            GameManager.instance.choiceSkill.SetActive(true);
            Interactable(player);
        }
        else if (!parameter && !player)
        {
            GameManager.instance.choiceSkill.SetActive(false);
            Interactable(player);
        }

        void Interactable(bool playerInterec)
        {
            if (playerInterec)
            {
                GameObject[] skillChild = new GameObject[skill.transform.childCount];
                for (int i = 0; i < skillChild.Length; i++)
                {
                    skillChild[i] = skill.transform.GetChild(i).gameObject;
                    skillChild[i].GetComponent<Button>().interactable = true;
                }
            }
            else if (!playerInterec)
            {
                GameObject[] skillChild = new GameObject[skill.transform.childCount];
                for (int i = 0; i < skillChild.Length; i++)
                {
                    skillChild[i] = skill.transform.GetChild(i).gameObject;
                    skillChild[i].GetComponent<Button>().interactable = false;
                }
            }

        }
    }

    public void AnimasiSkill(int skill)
    {
        ChoiceSkill(false, true);

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            GameObject skillObject = Instantiate(animasiSkill, transform.position + new Vector3(-4f, 8, 0), Quaternion.Euler(10, 90, 0));
            yield return new WaitForSeconds(1f);
            if (skill == 1)
            {
                skillObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (skill == 2)
            {
                skillObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (skill == 3)
            {
                skillObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (skill == 4)
            {
                skillObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(true);
            }
            else if (skill == 5)
            {
                skillObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(4f);
            Destroy(skillObject);
        }


    }
    void Draw()
    {
        for (int i = 0; i < cardPlayer.Length; i++)
        {
            if (cardControllerP[i] != null)
            {
                cardControllerP[i].BackLobby();
            }
        }
        for (int i = 0; i < cardEnemy.Length; i++)
        {
            if (cardControllerE[i] != null)
            {
                cardControllerE[i].BackLobby();
            }
        }

        //Text
        botController.elementText.text = "";
        //Cam
        animasiCam.ViewCam();
        //Bot
        allButton.SetActive(true);
        botController.RandomElement();
    }

    void PlayerLose()
    {
        GameObject[] skillChild = new GameObject[skill.transform.childCount];
        for (int i = 0; i < skillChild.Length; i++)
        {
            skillChild[i] = skill.transform.GetChild(i).gameObject;
        }
        int randomSkill = Random.Range(0, skill.transform.childCount);
        print("Random Skill yang dirandom " + randomSkill);
        BattleSkill battleSkill = skillChild[randomSkill].GetComponent<BattleSkill>();
        battleSkill.SkillEnmey();
    }

    public void PlayGame(bool play)
    {
        if (play)
        {
            for (int i = 0; i < cardControllerP.Length; i++)
            {
                cardControllerP[i].playGame = true;
            }
        }
        else
        {
            for (int i = 0; i < cardControllerP.Length; i++)
            {
                cardControllerP[i].playGame = false;
            }
        }
    }
}
