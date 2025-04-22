using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    CharacterMovement characterMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        WASD_Input();
        LeftMouse();
        RightMouse();
        JumpSpace();
    }

    private void JumpSpace()
    {
        characterMovement.jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W);
    }

    private void RightMouse()
    {
        characterMovement.rightMouse = Input.GetKeyDown(KeyCode.Mouse1);
    }

    private void LeftMouse()
    {
        characterMovement.leftMouse = Input.GetKeyDown(KeyCode.Mouse0);
    }

    private void WASD_Input()
    {
        characterMovement.inputDir = Input.GetAxis("Horizontal");
    }
}
