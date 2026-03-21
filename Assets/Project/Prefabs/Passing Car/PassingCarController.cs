using UnityEngine;

public class PassingCarController : MonoBehaviour
{
    [SerializeField] float _speed;

    private Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 velocity = new(0, 0, -_speed);
        _rigidbody.linearVelocity = velocity;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, transform.parent.position) >  400)
        {
            gameObject.SetActive(false);
        }
    }
}
