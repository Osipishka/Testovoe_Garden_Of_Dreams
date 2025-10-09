using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Testovoe_Garden_Of_Dreams.Core;

public class BuildingInputHandler : MonoBehaviour
{
    [Header("Input Events")]
    public UnityEvent<Vector2> OnLeftClick;
    public UnityEvent<Vector2> OnRightClick;
    public UnityEvent OnEscape;
    public UnityEvent<Vector2> OnMouseMove;

    private BuildingInputs inputActions;
    private Camera mainCamera;

    private void Awake()
    {
        inputActions = new BuildingInputs();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        inputActions.Mouse.LeftClick.performed += OnLeftClickPerformed;
        inputActions.Mouse.RightClick.performed += OnRightClickPerformed;
        inputActions.Keyboard.Escape.performed += OnEscapePerformed;
        inputActions.Mouse.Position.performed += OnMouseMovePerformed;

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Mouse.LeftClick.performed -= OnLeftClickPerformed;
        inputActions.Mouse.RightClick.performed -= OnRightClickPerformed;
        inputActions.Keyboard.Escape.performed -= OnEscapePerformed;
        inputActions.Mouse.Position.performed -= OnMouseMovePerformed;

        inputActions.Disable();
    }

    private void OnLeftClickPerformed(InputAction.CallbackContext context)
    {
        OnLeftClick?.Invoke(GetMouseWorldPosition());
    }

    private void OnRightClickPerformed(InputAction.CallbackContext context)
    {
        OnRightClick?.Invoke(GetMouseWorldPosition());
    }

    private void OnEscapePerformed(InputAction.CallbackContext context)
    {
        OnEscape?.Invoke();
    }

    private void OnMouseMovePerformed(InputAction.CallbackContext context)
    {
        OnMouseMove?.Invoke(GetMouseWorldPosition());
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector2 mousePos = inputActions.Mouse.Position.ReadValue<Vector2>();
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}