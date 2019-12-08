using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLivesCollider : MonoBehaviour
{
    BaseLivesManager baseLives;
    private void Start()
    {
        baseLives = FindObjectOfType<BaseLivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Attacker>())
        {
            baseLives.SpendLives(1);
        }
    }
}
