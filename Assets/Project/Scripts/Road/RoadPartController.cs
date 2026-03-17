using UnityEngine;

public class RoadPartController : MonoBehaviour
{
    [SerializeField] float _movespeed = 5f;
    [SerializeField] Transform _resetPostion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = new(0, 0,-_movespeed * Time.deltaTime);

        transform.position = transform.position + velocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Teleporter")
        {
            transform.position = _resetPostion.position;
        }
    }
}
