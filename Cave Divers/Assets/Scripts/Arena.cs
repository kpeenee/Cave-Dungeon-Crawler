using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField] GameObject arenaBounds;

    public event Action OnArenaEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Arena Battle Start!!");
            arenaBounds.SetActive(true);
            OnArenaEnter();
        }
    }

    private void Update()
    {
        if(transform.childCount == 1)
        {
            Destroy(gameObject);
        }
    }
}
