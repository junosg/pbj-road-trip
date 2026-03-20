using UnityEngine;

public class SeatSanityEvent : SanityEvent
{
    public override void OnActivate()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public override void OnDeactivate()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Update()
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
