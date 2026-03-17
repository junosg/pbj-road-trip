using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movespeed = 5f;
    [SerializeField] float _lookspeed = 100f;
    [SerializeField] GameObject _lookTarget;

    private InputSystem_Actions _inputActions;
    private InputAction _move;
    private InputAction _look;

    void OnEnable()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();

        _move = _inputActions.Player.Move;
        _move.Enable();

        _look = _inputActions.Player.Look;
        _look.Enable();
    }

    void OnDisable()
    {
        _move.Disable();
        _look.Disable();
        _inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        Vector3 velocity = new(moveInput.x * _movespeed * Time.deltaTime, 0f, moveInput.y * _movespeed * Time.deltaTime);

        transform.position = transform.position + velocity;
    }

    void Look()
    {
        Vector2 lookInput = _look.ReadValue<Vector2>();

        _lookTarget.transform.Rotate(_lookspeed * lookInput.x * Time.deltaTime * Vector3.up, Space.World);
    }
}
