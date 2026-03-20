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
            PlayerController.Instance._isTurnOff = false;
            SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * Time.deltaTime);

            if (PlayerController.Instance._isTurnOff)
            {
                Deactivate();
            }
        }
    }
    
}
