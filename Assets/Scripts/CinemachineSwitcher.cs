using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private InputAction action;

    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera combatCamera;

    private bool FollowCamera = true;


    
    
    
    
    void Start()
    {
        action.performed += _ => SwitchPriority();
    }

    private void SwitchPriority()
    {
        if (FollowCamera)
        {
            followCamera.Priority = 0;
            combatCamera.Priority = 1;
        }
        else
        {
            followCamera.Priority = 1;
            combatCamera.Priority = 0;
        }

        FollowCamera = !FollowCamera;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }


    void Update()
    {
        
    }
}
