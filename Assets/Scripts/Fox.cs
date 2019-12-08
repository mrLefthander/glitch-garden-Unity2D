using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.tag == "Barricade")
            {
                FoxJump();
            }
            else
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }
    }

    private void FoxJump()
    {
        GetComponent<Animator>().SetTrigger("jumpTrigger");
    }
}
