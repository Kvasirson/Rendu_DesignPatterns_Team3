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

    GameObject _interactHighlight;

    #endregion

    private void Awake()
    {
        //Set Object Display Image
        m_objectSpriteRenderer.sprite = m_equipementData.Sprite;

        //Set Highlight
        _interactHighlight = Instantiate(new GameObject(), transform.position, transform.rotation, transform);
        SpriteRenderer HighlightRend = _interactHighlight.AddComponent<SpriteRenderer>();
        HighlightRend.sprite = m_equipementData.Sprite;
        HighlightRend.color = Color.white;
        HighlightRend.rendererPriority = m_objectSpriteRenderer.rendererPriority - 1;
        _interactHighlight.transform.localScale = Vector3.one * 1.1f;

        _interactHighlight.SetActive(false);
    }

    public void Interact()
    {
        OnPickup();
    }

    public void Interactable(bool isInteractable)
    {
        _interactHighlight.SetActive(isInteractable);
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
