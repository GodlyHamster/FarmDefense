using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Wave> enemyWaves = new List<Wave>();

    [SerializeField]
    private Bounds spawningArea = new Bounds();

    private int currentWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (Wave wave in enemyWaves)
        {
            foreach (EnemyWaveGroup waveGroup in wave.enemies)
            {
                for (int i = 0; i < waveGroup.amount; i++)
                {
                    Vector3 randomSpawnPos = spawningArea.center + new Vector3(
                        UnityEngine.Random.Range(-spawningArea.extents.x, spawningArea.extents.x),
                        UnityEngine.Random.Range(-spawningArea.extents.y, spawningArea.extents.y));
                    Instantiate(waveGroup.enemyPrefab, randomSpawnPos, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                }
            }
        }
        yield return null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 0, 0, 100);
        Gizmos.DrawCube(spawningArea.center, spawningArea.extents);
    }
#endif
}

[Serializable]
public class Wave
{
    [field: SerializeField]
    public float timeUntilWave { get; private set; }
    [field: SerializeField]
    public List<EnemyWaveGroup> enemies { get; private set; } = new List<EnemyWaveGroup>();
}

[Serializable]
public class EnemyWaveGroup
{
    public GameObject enemyPrefab;
    public int amount;
}
