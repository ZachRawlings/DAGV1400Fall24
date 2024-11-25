using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehavior : MonoBehaviour
{
    public ID id;
    public UnityEvent matchEvent, noMatchEvent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherID = other.GetComponent<SimpleIDBehaviour>();
        
        if (otherID.id == id)
        {
            Debug.Log("Matched ID: " + id);
            matchEvent.Invoke();
        }
        else
        {
            Debug.Log("No Match:" + id);
            noMatchEvent.Invoke();
        }
    }
}

