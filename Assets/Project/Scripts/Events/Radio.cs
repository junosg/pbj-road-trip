using UnityEngine;

public class Radio : MonoBehaviour, IEvent
{
    [SerializeField] AudioClip sanityClip;
    
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
        SoundManager.Instance.PlaySfx(sanityClip);
        SanityManager.Instance.DecreaseSanity(1);
    }
}
