using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    private const int MinMedkitsCount = 1;
    private const int MaxMedkitsCount = 4;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Medkit _prefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int medkitsCount = UnityEngine.Random.Range(MinMedkitsCount, MaxMedkitsCount + 1);

        for (int i = 0; i < medkitsCount; i++)
        {
            Instantiate(_prefab, _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)]);
        }
    }
}
