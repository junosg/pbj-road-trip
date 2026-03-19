using UnityEngine;

public class Seat : MonoBehaviour, IEvent 
{
    
    [SerializeField] GameObject seat;
    public bool hasAppeared;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Appear()
    {
        hasAppeared = true;
        seat.SetActive(true);
        SanityManager.Instance.DecreaseSanity(5);
    }

}
