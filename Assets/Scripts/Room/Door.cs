using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    [SerializeField, Required]
    private GameObject m_doorObject;

    private RoomController _roomController;

    private void Awake()
    {
        m_doorObject = m_doorObject != null ? m_doorObject : transform.GetChild(0).gameObject;

        _roomController = transform.parent.GetComponent<RoomController>();
    }

    private void Start()
    {
        _roomController.OnRoomLock += Close;
        _roomController.OnRoomOpen += Open;
        Open();
    }

    private void Reset()
    {
        m_doorObject = m_doorObject != null ? m_doorObject : transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collision

        _roomController.LockRoom();
    }

    public void Open()
    {
        if (m_doorObject == null)
            return;

        m_doorObject.SetActive(false);
    }

    public void Close()
    {
        if (m_doorObject == null)
            return;

        m_doorObject.SetActive(true);
    }
}
