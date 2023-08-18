using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickHandler : MonoBehaviour
{
    private Camera _mainCamera;

    // Getting access to duringAbility attribute
    private RPSAbilities rpsAbilities;
    private RPSType rpsType;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        // Getting access to duringAbility attribute
        rpsAbilities = FindObjectOfType<PlayerMovement>().GetComponent<RPSAbilities>();
        rpsType = FindObjectOfType<PlayerMovement>().GetComponent<RPSType>();
    }


    public void OnClick(InputAction.CallbackContext context)
    {
        if (rpsAbilities.duringAbility && rpsType.Type == Type.Scissor)
        {
            if (!context.started) return;

            var rayHit = Physics.Raycast(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()), out RaycastHit info);
            if (!info.collider) return;

            if (info.collider.gameObject.tag == "Enemy")
            {
                info.collider.gameObject.transform.localScale *= 0.5f;

                if (info.collider.gameObject.transform.localScale.x < 1.0f)
                {
                    info.collider.gameObject.transform.localScale = Vector3.one;
                }
            }
        }
    }
    
}
