using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour, IInteract
{

    public void Display()
    {
        Debug.Log("Press E");
    }

    public void Interact()
    {
        SceneManager.LoadScene(1);
    }

    public void UnDisplay()
    {
        Debug.Log("OK!!");
    }
}
