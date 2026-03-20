using UnityEngine;

public class Seat : MonoBehaviour, IEvent 
{
    
    [SerializeField] GameObject seat;
    public bool Active { get; set; }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            SanityManager.Instance.DecreaseSanity(5);
        }
    }

    public void Appear()
    {
        Active = true;
        seat.SetActive(true);
        SanityManager.Instance.DecreaseSanity(5);
    }

    
}
