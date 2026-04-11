using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    public event Action<Item> GettedItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            GettedItem?.Invoke(item);

            Debug.Log("item selected");
        }
    }
}
