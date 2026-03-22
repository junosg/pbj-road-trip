using System;
using UnityEngine;

public class MirrorSanityEvent : SanityEvent
{
    [SerializeField] GhostScareController _ghostScareController;
    [SerializeField] float _delayUntilResolved = 3f;

    public override void OnActivate()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        PlayerController.Instance.MirrorFocused.AddListener(OnMirrorFocused);
    }

    public override void OnDeactivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void OnIgnored()
    {
        _ghostScareController.TriggerScare();
        SanityManager.Instance.DecreaseSanity(5);
        Deactivate();
    }

    public void Update()
    {
        if (Activated)
        {
            SanityManager.Instance.DecreaseSanity(sanityDecreaseSpeed * Time.deltaTime);

            if (IsOnCamera())
            {
                Deactivate();
            }
        }
    }

    public void OnMirrorFocused(bool value)
    {
        if (value)
        {
            Invoke("Deactivate", _delayUntilResolved);
        } else
        {
            CancelInvoke("Deactivate");
        }
    }
}
