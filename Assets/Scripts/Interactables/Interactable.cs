using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Message to be displayed to player when looking at an interactable.
    public string promptMessage;

    // Function will be called from player.
    public void BaseInteract()
    {
        Interact();
    }

    // Function to be overwritten by subclasses.
    protected virtual void Interact()
    { }
}
