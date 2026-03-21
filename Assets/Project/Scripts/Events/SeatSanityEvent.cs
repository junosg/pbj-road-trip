using UnityEngine;

public class SeatSanityEvent : SanityEvent
{
    [SerializeField] AudioClip _whisperClip;

    private bool _isIgnored = false;

    public override void OnActivate()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void OnDeactivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void OnIgnored()
    {
        _isIgnored = true;
        SoundManager.Instance.PlaySingle(_whisperClip);
    }

    void Update()
    {
        if (Activated)
        {
            if (_isIgnored)
            {
                if (SoundManager.Instance.IsSingleSourcePlaying())
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
