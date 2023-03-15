using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (InputManager.InputSystem.IsShoot) 
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        
    }
}
