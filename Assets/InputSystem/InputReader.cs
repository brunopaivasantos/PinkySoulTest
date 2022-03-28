using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputReader : MonoBehaviour, PlayerControls.IGameActions
{
    public event UnityAction JumpEvent;

    private PlayerControls playerControls;
    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Game.SetCallbacks(this);
            playerControls.Game.Enable();
        }
    }

    private void OnDisable()
    {
        playerControls.Game.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
       if (JumpEvent != null && context.phase == InputActionPhase.Performed)
        {
            JumpEvent.Invoke();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
