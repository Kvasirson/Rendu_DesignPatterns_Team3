using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    #region Variables

    [SerializeField]
    float m_cameraBaseMoveSpeed = 0.1f;
    [SerializeField] 
    float m_cameraMaxMoveSpeed = 3f;

    [SerializeField]
    Transform m_target;

    [SerializeField, Required]
    Camera m_camera;

    float _baseSize;

    #endregion

    private void LateUpdate()
    {
        if(m_target == null) //Null check
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, m_target.position);
        if (distance > 0.2f) //Move Toward Target
        {
            Vector2 direction = (transform.position - m_target.position).normalized;

            float speed = m_cameraBaseMoveSpeed * distance;
            if(speed > m_cameraMaxMoveSpeed)
            {
                speed= m_cameraMaxMoveSpeed;
            }

            transform.position += (Vector3)direction * speed;
        }
        else //Teleport to target if close enough
        {
            transform.position = m_target.position;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        m_target = newTarget;
    }

    public void SetCameraSize(float size)
    {
        m_camera.orthographicSize = size;
    }

    public void ResetValues()
    {
        m_camera.orthographicSize = _baseSize;
        //Target == player
    }

    private void Reset()
    {
        //Set Cam
        m_camera = GetComponent<Camera>();

        _baseSize = m_camera.orthographicSize;
    }
}
