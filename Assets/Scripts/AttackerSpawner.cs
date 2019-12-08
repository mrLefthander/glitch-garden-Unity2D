using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    LevelController levelController;

    IEnumerator Start()
    {
        levelController = FindObjectOfType<LevelController>();
        while (!levelController.GetLevelTimerEnded())
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var randomAttackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[randomAttackerIndex]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        if (!levelController.GetLevelTimerEnded())
        {
            Attacker newAttacker =
                        Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
            newAttacker.transform.parent = transform;
            levelController.AttackerSpawned();
        }
    }
}
