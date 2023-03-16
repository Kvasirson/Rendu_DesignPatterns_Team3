using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    #region Variables

    [SerializeField]
    float m_interactionRange = 2f;

    [SerializeField]
    LayerMask m_interactionMask;


    Collider2D _targetInteractableCollider;
    IInteractable _targetInteractableScript;

    #endregion

    void Update()
    {
        //Check for interactable objects in range
        Collider2D[] interactableColliders = new Collider2D[3];
        int foundObjects = Physics2D.OverlapCircleNonAlloc(transform.position, m_interactionRange, interactableColliders, m_interactionMask);
        //If interactable objects in range
        if (foundObjects > 0)
        {
            //Check for closest object
            float shortestDistance = Mathf.Infinity;
            int shortestIndex = 0;
            for (int index = 0; index < interactableColliders.Length; index++)
            {
                //Null check
                if (interactableColliders[index] == null)
                {
                    break;
                }

                //Distance checkxtt
                float distance = Vector3.Distance(transform.position, interactableColliders[index].transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    shortestIndex = index;
                }
            }

            //If current targeted object is no longer the closest, reset it
            if (_targetInteractableCollider != null && _targetInteractableCollider != interactableColliders[shortestIndex])
            {
                _targetInteractableScript.Interactable(false);
                _targetInteractableScript = null;
                _targetInteractableCollider = null;
            }

            //Set current target object
            _targetInteractableCollider = interactableColliders[shortestIndex];
            if (_targetInteractableCollider != null && _targetInteractableCollider.TryGetComponent(out IInteractable interactable))
            {
                _targetInteractableScript = interactable;
                _targetInteractableScript.Interactable(true);
            }
        }
        //If no interactable object in range
        else
        {
            //Reset current targeted object
            if (_targetInteractableCollider != null)
            {
                _targetInteractableScript.Interactable(false);
                _targetInteractableScript = null;
                _targetInteractableCollider = null;
            }
        }
    }

    //On Interact Action
    void Interact(InputAction.CallbackContext context)
    {
        if (_targetInteractableCollider != null && _targetInteractableCollider.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        //Interaction Range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_interactionRange);
    }
}
