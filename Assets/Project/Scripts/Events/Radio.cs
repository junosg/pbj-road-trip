using UnityEngine;

public class Radio : SanityEvents
{
    [SerializeField] AudioClip sanityClip;
    public override bool Active { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void Appear()
    {
        //Play Sound
        Debug.Log("Radio Appear");
        SoundManager.Instance.PlaySfx(sanityClip);
        SanityManager.Instance.DecreaseSanity(1);
        Active = true;
    }
    
}
