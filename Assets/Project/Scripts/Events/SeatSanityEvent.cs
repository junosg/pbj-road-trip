using UnityEngine;

public class SeatSanityEvent : SanityEvent
{
    [SerializeField] AudioClip _whisperClip;
    [SerializeField] AudioSource _whisperSource;
    [SerializeField] TutorialController _tutorialController;
    private bool _tutorialTriggered = false;

    private bool _isIgnored = false;

    public override void OnActivate()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        if (_tutorialTriggered == false)
        {
            StartCoroutine(_tutorialController.DisplayPassengerTutorial(2));
            _tutorialTriggered = true;
        }
        
    }

    public override void OnDeactivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void OnIgnored()
    {
        _isIgnored = true;
        _whisperSource.PlayOneShot(_whisperClip);
    }

    void Update()
    {
        if (Activated)
        {
            if (_isIgnored)
            {
                if (_whisperSource.isPlaying)
                {
                    SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * 2 * Time.deltaTime);
                } else
                {
                    Deactivate();
                }
            } else
            {
                SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * Time.deltaTime);
            }
            
            if (IsOnCamera())
            {
                Deactivate();
            }
        }
    }
}
