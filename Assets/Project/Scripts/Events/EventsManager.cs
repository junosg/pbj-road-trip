using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventsManager : MonoBehaviour
{
    
    public List<SanityEvents> events;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] goEvents = GameObject.FindGameObjectsWithTag("Event");

        foreach (GameObject go in goEvents)
        {
            events.Add(go.GetComponent<SanityEvents>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnableEvents();
    }
    
    
    void EnableEvents()
    {
        var randomIndex = Random.Range(0, 7);

        if (randomIndex < events.Count)
        {
            events[randomIndex].Appear();
        }
    }

    void DisableEvents()
    {
        
    }
}
