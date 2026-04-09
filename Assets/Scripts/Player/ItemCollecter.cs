using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public event Action<float> GettedMedkit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item is Money)
            {
                _inventory.AddItem(item);
                item.transform.parent = _inventory.transform;
                item.transform.localPosition = _inventory.transform.position;
                item.gameObject.SetActive(false);
            }
            else if (item is Medkit)
            {
                Medkit medkit = item.GetComponent<Medkit>();

                GettedMedkit?.Invoke(medkit.Count);
                Destroy(medkit.gameObject);
            }
        }
    }
}
