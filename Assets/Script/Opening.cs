using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    public bool credit, story;

    IEnumerator Start()
    {
        Application.targetFrameRate = 60;

        if (story)
        {
            yield return new WaitForSeconds(42);
            GameManager.instance.StartTransisi();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("PilihCard");
        }

        if (credit)
        {
            yield return new WaitForSeconds(93f);
            GameManager.instance.StartTransisi();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Mainmenu");
        }
        else if (!credit)
        {
            yield return new WaitForSeconds(16f);
            SceneManager.LoadScene("Mainmenu");
        }

    }
}
