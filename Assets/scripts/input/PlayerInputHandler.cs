using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Unknown.HelperTools.Extentions;

public class PlayerInputHandler : MonoBehaviour
{
	public Vector2 RawMovementInput { get; private set; }
    public Vector2 MouseDelta { get; private set; }
	public bool IsJumping { get; private set; }
	public bool IsRunning { get; private set; }

	public void onJumpInput(InputAction.CallbackContext ctx)
	{
		if (ctx.performed)
		{
			IsJumping = true;
		}

		if (ctx.canceled)
		{
			IsJumping = false;
		}
	}

    public void onRunningInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            IsRunning = true;
        }

        if (ctx.canceled)
        {
            IsRunning = false;
        }
    }

    public void onMovementInput(InputAction.CallbackContext ctx)
	{
		RawMovementInput = ctx.ReadValue<Vector2>();
	}

	public void onMouseMovement(InputAction.CallbackContext ctx)
	{
		MouseDelta = ctx.ReadValue<Vector2>();
	}
}
