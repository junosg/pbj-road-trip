using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movespeed = 5f;
    [SerializeField] float _lookspeed = 100f;
    [SerializeField] Vector2 _moveLimit;
    [SerializeField] GameObject _lookTarget;
    [SerializeField] GameObject _focusTarget;

    [SerializeField] AudioClip _carMovingClip;
    [SerializeField] SteeringWheelController _steeringWheel;

    private InputSystem_Actions _inputActions;
    private InputAction _move;
    private InputAction _look;
    private InputAction _focus;
    private InputAction _radioToggle;

    public UnityEvent RadioToggled = new();

    public bool _isViewing;

    public static PlayerController Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    void OnEnable()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();

        _move = _inputActions.Player.Move;
        _move.Enable();

        _look = _inputActions.Player.Look;
        _look.Enable();
        
        _focus = _inputActions.Player.Focus;
        _focus.Enable();

        _radioToggle = _inputActions.Player.RadioToggle;
        _focus.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        _move.Disable();
        _look.Disable();
        _inputActions.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        DisableMovement();

        _radioToggle.performed += TurnOffRadio;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
        LookAtMirror();
    }

    void Move()
    {
        Vector2 moveInput = _move.ReadValue<Vector2>();
        _steeringWheel.SetSteeringWheelPosition(moveInput.x);

        Vector3 velocity = new(moveInput.x * _movespeed * Time.deltaTime, 0f, moveInput.y * _movespeed * Time.deltaTime);
        Vector3 newPosition = new(Mathf.Clamp(transform.position.x + velocity.x, _moveLimit.x, _moveLimit.y), transform.position.y + velocity.y, transform.position.z + velocity.z);

        transform.position = newPosition;
    }

    void Look()
    {
        Vector2 lookInput = _look.ReadValue<Vector2>();

        _lookTarget.transform.Rotate(_lookspeed * lookInput.x * Time.deltaTime * Vector3.up, Space.World);
    }

    void LookAtMirror()
    {
        if (_focus.triggered)
        {

            if (_isViewing == false)
            {
                
                _lookTarget.transform.LookAt(_focusTarget.transform);
                CameraManager.Instance.ZoomIn();
                _look.Disable();
                _isViewing = true;
            }
            else
            {
                Vector3 resetPosition = new Vector3(0f, 0.441f, 0f);

                _lookTarget.transform.localPosition = resetPosition;
                _lookTarget.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                CameraManager.Instance.ZoomOut();
                _look.Enable();
                _isViewing = false;
            }
        }
    }

    public void TurnOffRadio(InputAction.CallbackContext context)
    {
        RadioToggled.Invoke();
    }

    public void DisableMovement()
    {
        _move.Disable();
    }

    public void EnableMovement()
    {
        _move.Enable();
    }

    public void PlayCarMovingClip()
    {
        SoundManager.Instance.PlaySfx(_carMovingClip);
    }
}
