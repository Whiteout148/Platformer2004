using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    [SerializeField] private List<Item> _items = new List<Item>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            _items.Add(item);
            item.gameObject.SetActive(false);
        }
    }
}
