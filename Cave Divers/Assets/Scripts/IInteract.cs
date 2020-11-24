using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract 
{
    GameObject gameObject { get; }
    //Player interaction
    void Interact();

    //UI display
    void Display();
}
