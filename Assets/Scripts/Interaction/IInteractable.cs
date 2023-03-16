using UnityEngine;

interface IInteractable
{
    //True if can be interacted with
    void Interactable(bool isInteractable);

    //Triggered when interacted with (string for context)
    void Interact();
}
