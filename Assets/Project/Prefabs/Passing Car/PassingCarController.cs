using UnityEngine;

public class PassingCarController : MonoBehaviour
{
    [SerializeField] float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new(0, 0,-_speed * Time.deltaTime);

        transform.position = transform.position + velocity;
    }
}
