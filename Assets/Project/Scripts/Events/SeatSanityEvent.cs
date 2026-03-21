using UnityEngine;

public class SeatSanityEvent : SanityEvent
{
    [SerializeField] GhostScareController _ghostScareController;

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
        Debug.Log("triggered");

        _ghostScareController.TriggerScare();
        SanityManager.Instance.DecreaseSanity(5);
        Deactivate();
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
