using UnityEngine;

public class RadioSanityEvent : SanityEvent
{
    
    [SerializeField] AudioClip radioSanitySound;
    
    public override void OnActivate()
    {
        SoundManager.Instance.PlayMusic(radioSanitySound);
    }

    public override void OnDeactivate()
    {
        Activated = false;
    }

    public void Update()
    {
        if (Activated)
        {
            SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * Time.deltaTime);
            
        }
    }
    
}
