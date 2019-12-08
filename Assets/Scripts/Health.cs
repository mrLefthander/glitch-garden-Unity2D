using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] GameObject deathVFX;

    DefenderSpawner defenderSpawner;
    LevelController levelController;

    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        levelController = FindObjectOfType<LevelController>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.layer == 9)
        {
            levelController.AttackerKilled();
        }
        else if (gameObject.layer == 8)
        {
            defenderSpawner.RemoveDefenderFromList(gameObject.GetComponent<Defender>());
        }
        
        TriggerDeathVFX();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
