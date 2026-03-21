using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
    Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSteeringWheelPosition(float value)
    {
        _animator.SetFloat("positionX", value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
