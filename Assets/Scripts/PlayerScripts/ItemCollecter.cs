using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _inventory.AddItem(item);
            item.transform.parent = _inventory.transform;
            item.transform.localPosition = _inventory.transform.position;
            item.gameObject.SetActive(false);
        }
    }
}
