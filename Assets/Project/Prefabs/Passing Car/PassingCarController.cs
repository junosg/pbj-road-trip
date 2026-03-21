using UnityEngine;

public class PassingCarController : MonoBehaviour
{
    [SerializeField] float _speed;

    private Rigidbody _rigidbody;
    private bool _collided = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_collided) return;

        Vector3 velocity = new(0, 0, -_speed);

        _rigidbody.linearVelocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        _collided = true;
    }
}
