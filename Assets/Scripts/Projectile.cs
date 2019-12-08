using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] int damage = 10;

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var attackerHealth = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if (!attackerHealth && !attacker) { return; }
        
        attackerHealth.DealDamage(damage);

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
