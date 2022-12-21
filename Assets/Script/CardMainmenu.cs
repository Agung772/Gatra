using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMainmenu : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Animator animator;

    IEnumerator Start()
    {
        Destroy(gameObject, 4);
        rigidbody.angularVelocity = new Vector3(0, Random.Range(-2, 2), 0);
        yield return new WaitForSeconds(1);
        rigidbody.useGravity = true;

    }

}
