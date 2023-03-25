using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RoomController : MonoBehaviour
{
    #region Variables

    [SerializeField]
    GameObject[] m_doors;

    [SerializeField]
    Collider2D m_roomTrigger;

    [SerializeField, Required]
    CameraController m_cameraController;
    
    [SerializeField, Required]
    Camera m_roomCamera;

    bool _completed = false;

    #endregion

    private void Awake()
    {
        //Open room
        foreach (GameObject door in m_doors)
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player check

        if (!_completed) //Already completed room check
        {
            LockRoom();
        }
    }

    void LockRoom()
    {
        //Close room
        foreach (GameObject door in m_doors)
        {
            door.SetActive(true);
        }

        //Set camera for room
        m_cameraController.SetTarget(m_roomCamera.transform);
        m_cameraController.SetCameraSize(m_roomCamera.orthographicSize);
    }

    public void UnlockRoom()
    {
        //Open room
        foreach (GameObject door in m_doors)
        {
            door.SetActive(false);
        }

        //Set room completion
        _completed = true;

        //Reset camera
        m_cameraController.ResetValues();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(m_roomTrigger.bounds.center, m_roomTrigger.bounds.size);
    }
#endif
}
