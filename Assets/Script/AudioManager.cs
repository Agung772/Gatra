using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public Slider slider;
    public int saveVolume;
    public AudioClip clickButtonSfx, attackSfx, shieldSfx, fireSfx, healSfx;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        saveVolume = PlayerPrefs.GetInt("Volume");
        audioSource.volume = (float)saveVolume / 5;
        slider.value = (float)saveVolume;
    }

    public void OnValueChanged()
    {
        saveVolume = (int)slider.value;
        audioSource.volume = (float)saveVolume / 5;
        PlayerPrefs.SetInt("Volume", saveVolume);
    }


    public void DefaultVol()
    {
        PlayerPrefs.SetInt("Volume", 3);
        print(PlayerPrefs.GetInt("Volume"));
    }
    public void PlusVolume(bool parameter)
    {
        if (Input.GetKeyDown(KeyCode.Equals) || parameter)
        {
            parameter = false;
            saveVolume++;
            audioSource.volume = (float)saveVolume / 5;
            saveVolume = Mathf.Clamp(saveVolume, 0, 5);
            PlayerPrefs.SetInt("Volume", saveVolume);
            slider.value = (float)saveVolume;

            AudioManager.instance.ButtonUISfx();
        }

    }
    public void MinusVolume(bool parameter)
    {
        if (Input.GetKeyDown(KeyCode.Minus) || parameter)
        {
            parameter = false;
            saveVolume--;
            audioSource.volume = (float)saveVolume / 5;
            saveVolume = Mathf.Clamp(saveVolume, 0, 5);
            PlayerPrefs.SetInt("Volume", saveVolume);
            slider.value = (float)saveVolume;

            AudioManager.instance.ButtonUISfx();
        }
    }

    public void ButtonUISfx()
    {
        audioSource.PlayOneShot(clickButtonSfx);
    }
    public void AttackSfx()
    {
        audioSource.PlayOneShot(attackSfx);
    }
    public void ShieldSfx()
    {
        audioSource.PlayOneShot(shieldSfx);
    }
    public void FireSfx()
    {
        audioSource.PlayOneShot(fireSfx);
    }
    public void HealSfx()
    {
        audioSource.PlayOneShot(healSfx);
    }
}
