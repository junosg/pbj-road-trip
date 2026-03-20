using UnityEngine;

public interface IEvent
{
    public void Appear();

    public bool Active { get; set; }
}
