using UnityEngine;

public class Seat : SanityEvents
{
    
    [SerializeField] GameObject seat;
    public override bool Active { get; set; }
 
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

    public override void Appear()
    {
        Debug.Log("Radio Appear");
        Active = true;
        seat.SetActive(true);
        SanityManager.Instance.DecreaseSanity(5);
    }

    
}
