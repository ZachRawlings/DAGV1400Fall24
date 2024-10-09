using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEvent : MonoBehaviour
{
   public UnityEvent triggerEvent;

   private void OnTriggerEnter2D(Collider2D other)
   {
      triggerEvent.Invoke();
      Debug.Log("Player interacted with the object!");
   }
}
