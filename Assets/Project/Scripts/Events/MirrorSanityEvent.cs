using System;
using UnityEngine;

public class MirrorSanityEvent : SanityEvent
{
    public override void OnActivate()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void OnDeactivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
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
}
