using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDistributor : MonoBehaviour
{
    [SerializeField] private ItemCollecter _collecter;
    [SerializeField] private Wallet _wallet;

    public event Action<float> GettedMedkit;
    
    private void OnEnable()
    {
        _collecter.GettedItem += OnGetItem;
    }

    private void OnDisable()
    {
        _collecter.GettedItem -= OnGetItem;
    }

    private void OnGetItem(Item item)
    {
        if (item is Money)
        {
            Money money = item.GetComponent<Money>();

            _wallet.AddMoney(money);
            money.transform.parent = _wallet.transform;
            money.gameObject.SetActive(false);
        }
        else if (item is Medkit)
        {
            Medkit medkit = item.GetComponent<Medkit>();

            GettedMedkit?.Invoke(medkit.Count);
            Destroy(medkit.gameObject);
        }
    }
}
