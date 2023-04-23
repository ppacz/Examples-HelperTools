using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unknown.StateMachine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private PlayerInputHandler inputHandler;
    [SerializeField]
    PlayerData playerData;

    float XRotation = 0f;
    float SensitivityX;
    float SensitivityY;

    private void Start()
    {
        SensitivityX = playerData.mouseSensitivity.x;
        SensitivityY = playerData.mouseSensitivity.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void LateUpdate()
    {
        processLook(inputHandler.MouseDelta);
    }

    public void processLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        XRotation -= (mouseY * Time.deltaTime) * SensitivityY;
        XRotation = Mathf.Clamp(XRotation, -80f, 80f);
        //rotate camera up and down
        cam.transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        //rotate player
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * SensitivityX);
    }
}
