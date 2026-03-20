using UnityEngine;

public class RoadController : MonoBehaviour
{
    private float _targetSpeed = 0;
    private float _currentSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentSpeed < _targetSpeed)
        {
            _currentSpeed += _currentSpeed + 1 * Time.deltaTime;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.SetFloat("_Speed", _currentSpeed);
            }
        }
    }

    public void SetRoadSpeed(float value)
    {
        _targetSpeed = value;
    }
}
