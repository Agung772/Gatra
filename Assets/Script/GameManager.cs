using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum IniSceneMana
    {
        gameplay, mainmenu, galery, pilihCard, credit, kosong
    }
    public IniSceneMana iniSceneMana;
    public AudioManager audioManager;
    public GameObject gameplayButton, mainmenuButton, galeryUI, options, pilihCardUI, choiceSkill, transisi, tutorUI, victoryUI, defeatUI;
    public ParticleSystem particleVic, particleDef;
    public TextMeshProUGUI fondAsset;
    public Options optionsScript;
    public BattleSkillManager battleSkillManager;
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        Application.targetFrameRate = 60;



        options.SetActive(false);

        if (iniSceneMana == IniSceneMana.gameplay)
        {
            ExitTransisi();

            gameplayButton.SetActive(true);
            mainmenuButton.SetActive(false);
            galeryUI.SetActive(false);
            pilihCardUI.SetActive(false);

            StartSkill();

            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                yield return new WaitForSeconds(1.3f);
                tutorUI.SetActive(true);
                Time.timeScale = 0;
            }


        }
        else if (iniSceneMana == IniSceneMana.mainmenu)
        {
            ExitTransisi();

            gameplayButton.SetActive(false);
            mainmenuButton.SetActive(true);
            galeryUI.SetActive(false);
            pilihCardUI.SetActive(false);
        }
        else if (iniSceneMana == IniSceneMana.galery)
        {
            ExitTransisi();

            gameplayButton.SetActive(false);
            mainmenuButton.SetActive(false);
            galeryUI.SetActive(true);
            pilihCardUI.SetActive(false);
        }
        else if (iniSceneMana == IniSceneMana.pilihCard)
        {
            ExitTransisi();

            gameplayButton.SetActive(false);
            mainmenuButton.SetActive(false);
            galeryUI.SetActive(false);
            pilihCardUI.SetActive(true);
        }
        else if (iniSceneMana == IniSceneMana.credit)
        {
            ExitTransisi();
        }
        else if (iniSceneMana == IniSceneMana.kosong)
        {
            AudioManager.instance.DefaultVol();
        }
    }
    private void Update()
    {
        Options(false);
        if (optionsBool)
        {
            audioManager.PlusVolume(false);
            audioManager.MinusVolume(false);
        }

    }
    void StartSkill()
    {
        battleSkillManager.Spawn5Skill();
    }
    public void ChangeText()
    {
        GameObject[] allText = GameObject.FindGameObjectsWithTag("Text");
        for (int i = 0; i < allText.Length; i++)
        {
            allText[i].GetComponent<TextMeshProUGUI>().font = fondAsset.font;
        }
    }

    bool optionsBool;
    public void Options(bool boolParameter)
    {
        if (Input.GetKeyDown(KeyCode.P) && !optionsBool || !optionsBool && boolParameter)
        {
            optionsScript.ExitAnimasi();

            boolParameter = false;
            optionsBool = true;
            options.SetActive(true);

            AudioManager.instance.ButtonUISfx();
        }
        else if (Input.GetKeyDown(KeyCode.P) && optionsBool || optionsBool && boolParameter)
        {
            optionsScript.ExitAnimasi();
            boolParameter = false;
            optionsBool = false;
            options.SetActive(false);

            AudioManager.instance.ButtonUISfx();
        }


    }
    public void PilihCard(int codeCard)
    {
        if (codeCard == 1)
        {
            PlayerPrefs.SetInt("CodeCard", codeCard);
        }
        else if (codeCard == 2)
        {
            PlayerPrefs.SetInt("CodeCard", codeCard);
        }
        LoadGameplay();

        AudioManager.instance.ButtonUISfx();
    }

    public void StartTransisi()
    {
        transisi.SetActive(true);
        transisi.GetComponent<Animator>().SetTrigger("Start");
    }
    public void ExitTransisi()
    {
        transisi.SetActive(true);
        transisi.GetComponent<Animator>().SetTrigger("Exit");
    }

    bool galeri, cooldownGaleri;
    public void GaleriUI()
    {
        if (!galeri && !cooldownGaleri)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                optionsScript.ExitAnimasi();

                StartTransisi();
                galeri = true;
                cooldownGaleri = true;
                yield return new WaitForSeconds(1f);
                galeryUI.SetActive(true);
                yield return new WaitForSeconds(1f);
                ExitTransisi();
                cooldownGaleri = false;
            }

        }
        else if (galeri && !cooldownGaleri)
        {
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                optionsScript.ExitAnimasi();

                StartTransisi();
                galeri = false;
                cooldownGaleri = true;
                yield return new WaitForSeconds(1f);
                galeryUI.SetActive(false);
                yield return new WaitForSeconds(1f);
                ExitTransisi();
                cooldownGaleri = false;
            }
        }

        AudioManager.instance.ButtonUISfx();

    }

    public void LoadPilihCard()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("PilihCard");
        }

        AudioManager.instance.ButtonUISfx();
    }
    public void LoadGameplay()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Gameplay");
        }

        AudioManager.instance.ButtonUISfx();
    }
    public void LoadStory()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Story");
        }

        AudioManager.instance.ButtonUISfx();
    }
    public void LoadMainmenu()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            optionsScript.ExitAnimasi();

            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Mainmenu");
        }

        AudioManager.instance.ButtonUISfx();
    }

    public void BackTutor()
    {
        tutorUI.SetActive(false);
        Time.timeScale = 1;

        AudioManager.instance.ButtonUISfx();
    }
    public void VictoryUI()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            victoryUI.SetActive(true);
            particleVic.Play();
            yield return new WaitForSeconds(8f);
            LoadMainmenu();
        }

    }
    public void DefeatUI()
    {

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            defeatUI.SetActive(true);
            particleDef.Play();
            yield return new WaitForSeconds(8f);
            LoadMainmenu();
        }
    }

    public void Credit()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("Credit");
        }

        AudioManager.instance.ButtonUISfx();
    }
    public void Quit()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            StartTransisi();
            yield return new WaitForSeconds(1.5f);
            Application.Quit();
        }
        AudioManager.instance.ButtonUISfx();
    }
}
