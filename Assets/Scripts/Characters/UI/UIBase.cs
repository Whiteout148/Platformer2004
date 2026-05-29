using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void Show()
    {
        transform.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
