using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BidakController : MonoBehaviour
{
    public bool player, enemy;
    public float hpBidak, maxHpBidak;
    public bool shield;
    public GameObject textDamage;
    public Image barHP;

    public ParticleSystem healPar, api;
    public Animator animatorShield;
    private void Start()
    {
        hpBidak = maxHpBidak;

        animatorShield.SetBool("Start", false);
    }
    public void Attack(float damage)
    {
        if (!shield)
        {
            GameObject text = Instantiate(textDamage, transform.position, transform.rotation);
            text.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
            text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage;
            Destroy(text, 3f);
            hpBidak -= damage;

            AudioManager.instance.AttackSfx();
        }
        else
        {
            Immune();
        }
        BarHP();
    }

    void AttackNonAudio(float damage)
    {
        GameObject text = Instantiate(textDamage, transform.position, transform.rotation);
        text.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage;
        Destroy(text, 3f);
        hpBidak -= damage;

        BarHP();
    }
    //Efek Skill
    //1. Skill Bakar
    //2. Skill criticall damage
    //3. Skill penambahan darah sebanyak 20%
    //4. Shield
    //5. Jalan 2×
    public void SkillBakar()
    {

        if (!shield)
        {
            StartCoroutine(Start());
            IEnumerator Start()
            {
                float damage = maxHpBidak / 20;
                api.Play();
                yield return new WaitForSeconds(2);
                AttackNonAudio(damage);
                yield return new WaitForSeconds(2);
                AttackNonAudio(damage);
                yield return new WaitForSeconds(2);
                AttackNonAudio(damage);
                api.Stop();
            }

            AudioManager.instance.FireSfx();
        }
        else
        {
            Immune();
        }
        BarHP();
    }

    public void Jalan2Kali(float damage)
    {

        Attack(damage);
        print("1");
        StartCoroutine(Start());
        IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            Attack(damage);
            print("2");

        }
    }

    public void Critical(float damage)
    {

        if (!shield)
        {
            GameObject text = Instantiate(textDamage, transform.position, transform.rotation);
            text.transform.GetChild(0).GetComponent<TextMeshPro>().fontSize = 19;
            text.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
            text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "-" + damage;
            text.transform.GetChild(0).GetComponent<TextMeshPro>().color = new Color(255, 0, 0, 255);
            Destroy(text, 3);
            hpBidak -= damage;
            print("Crit");
        }
        else
        {
            Immune();
        }
        BarHP();

        AudioManager.instance.AttackSfx();
    }
    public void HealHP(float heal)
    {
        healPar.Play();
        GameObject text = Instantiate(textDamage, transform.position, transform.rotation);
        text.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "+" + heal;
        text.transform.GetChild(0).GetComponent<TextMeshPro>().color = new Color(0, 255, 15, 255);
        Destroy(text, 3);
        hpBidak += heal;
        BarHP();

        AudioManager.instance.HealSfx();



    }
    public void Shield()
    {
        shield = true;
        animatorShield.SetBool("Start", true);

        AudioManager.instance.ShieldSfx();
    }

    public void Immune()
    {
        GameObject text = Instantiate(textDamage, transform.position, transform.rotation);
        text.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        text.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Immune";
        Destroy(text, 3);

        shield = false;
        animatorShield.SetBool("Start", false);
    }

    void BarHP()
    {
        barHP.fillAmount = hpBidak / maxHpBidak;
        hpBidak = Mathf.Clamp(hpBidak, 0, maxHpBidak);

        if (player)
        {
            if (hpBidak <= maxHpBidak / 2)
            {
                SpawnDialog.instance.SpawnTengah(true);
            }
            if (hpBidak <= 0)
            {
                SpawnDialog.instance.SpawnAkhir(true);
            }
        }
        if (enemy)
        {
            if (hpBidak <= maxHpBidak / 2)
            {
                SpawnDialog.instance.SpawnTengah(false);
            }
            if (hpBidak <= 0)
            {
                SpawnDialog.instance.SpawnAkhir(false);
            }
        }

        StartCoroutine(CoroutineDeath());
        IEnumerator CoroutineDeath()
        {
            yield return new WaitForSeconds(6);
            if (hpBidak <= 0)
            {
                print("Darah habis");
                if (player)
                {
                    GameManager.instance.DefeatUI();
                }
                if (enemy)
                {
                    GameManager.instance.VictoryUI();
                }

                GameObject dialogObject = GameObject.FindGameObjectWithTag("Dialog");
                if (dialogObject != null)
                {
                    dialogObject.GetComponent<DialogBox>().Exit();
                    print("Next dialog");
                }
            }
        }
    }

}
