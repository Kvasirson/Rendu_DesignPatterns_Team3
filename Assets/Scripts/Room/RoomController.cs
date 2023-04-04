using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    #region Variables

    [SerializeField, Required]
    CameraController m_cameraController;
    
    [SerializeField, Required]
    Camera m_roomCamera;

    bool _completed = false;

    public event Action OnRoomLock;
    public event Action OnRoomOpen;
    #endregion

    public void LockRoom()
    {
        if (_completed) return;

        //Close room
        OnRoomLock?.Invoke();

        //Set camera for room
        m_cameraController.SetTarget(m_roomCamera.transform);
        m_cameraController.SetCameraSize(m_roomCamera.orthographicSize);
    }

    public void UnlockRoom()
    {
        //Open room
        OnRoomOpen?.Invoke();

        //Set room completion
        _completed = true;

        //Reset camera
        m_cameraController.ResetValues();
    }
}
