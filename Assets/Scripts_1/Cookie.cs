using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private CookieManager cookieManager;

    private void Start()
    {
        cookieManager = CookieManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Destroy(gameObject);
        }
    }
}
