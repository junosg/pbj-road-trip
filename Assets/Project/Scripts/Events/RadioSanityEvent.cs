using UnityEngine;

public class RadioSanityEvent : SanityEvent
{
    
    [SerializeField] AudioClip radioSanitySound;
    
    public override void OnActivate()
    {
        SoundManager.Instance.PlayUI(radioSanitySound);
    }

    public override void OnDeactivate()
    {
        SoundManager.Instance.StopUI();
    }

    void Start()
    {
        PlayerController.Instance.RadioToggled.AddListener(Deactivate);
    }

    public void Update()
    {
        if (Activated)
        {
            SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * Time.deltaTime);
        }
    }
    
}
