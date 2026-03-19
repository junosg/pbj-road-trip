using UnityEngine;

public class Radio : MonoBehaviour, IEvent
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Appear()
    {
        //Play Sound
        SanityManager.Instance.DecreaseSanity(1);
    }
}
