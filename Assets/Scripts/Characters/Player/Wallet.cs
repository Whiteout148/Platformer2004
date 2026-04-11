using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private List<Money> _balance = new List<Money>();

    public void AddMoney(Money money)
    {
        _balance.Add(money);
    }
}
