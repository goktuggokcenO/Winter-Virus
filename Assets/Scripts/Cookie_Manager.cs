using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookieManager : MonoBehaviour
{
   public static CookieManager instance;
    private int cookies;
    [SerializeField] private TMP_Text cookiesDisplay;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }
    private void OnGUI()
    {
        cookiesDisplay.text = cookies.ToString();
    }
    public void ChangeCookie(int amount)
    {
        cookies += amount;
    }
}

