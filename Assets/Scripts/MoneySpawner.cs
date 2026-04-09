using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private List<MoneyPoint> _spawnPoints = new List<MoneyPoint>();
    [SerializeField] private Item _prefab;

    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Instantiate(_prefab, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
