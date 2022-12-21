using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    public Animator animator;
    public bool marshall, sadin;
    public GameObject marshallObject, sadinObject;
    public string isiString;
    public TextMeshProUGUI namaText, isiText;

    private void Start()
    {
        BattleManager.instance.PlayGame(false);

        if (marshall)
        {
            namaText.text = "Marshall";
            marshallObject.SetActive(true);
        }
        else if (sadin)
        {
            namaText.text = "Sadin";
            sadinObject.SetActive(true);
        }

        isiText.text = isiString;
    }

    bool use;
    public void Exit()
    {
        if (!use)
        {
            use = true;
            animator.SetBool("Start", false);
            Destroy(gameObject, 2);
            SpawnDialog.instance.SpawnAwal();

            AudioManager.instance.ButtonUISfx();

            BattleManager.instance.PlayGame(true);
        }

    }
}
