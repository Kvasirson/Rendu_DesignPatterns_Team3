using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class PlayerEquipement : MonoBehaviour, IInteractable
{
    #region Variables

    [SerializeField, Required]
    PlayerEquipementData m_equipementData;

    [SerializeField, Required]
    SpriteRenderer m_objectSpriteRenderer;

    #endregion

    private void Awake()
    {
        //Set Object Display Image
        m_objectSpriteRenderer.sprite = m_equipementData.Sprite;
    }

    public void Interact()
    {
        OnPickup();
    }

    public void Interactable(bool isInteractable)
    {
        throw new System.NotImplementedException();
    }

    void OnPickup()
    {
         //Add modifiers to player
    }

    public void OnRemove()
    {
        //Remove modifiers from player
    }

    void Reset()
    {
        //Set Renderer
        m_objectSpriteRenderer = GetComponent<SpriteRenderer>(); ;
    }
}
