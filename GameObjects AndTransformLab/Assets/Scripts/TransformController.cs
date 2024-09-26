using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    private void Update()
        {
            //Move the target GameObject
               var x = Mathf.PingPong(Time.time, 3);
               var y = Mathf.PingPong(Time.time, 3);
               var p = new Vector3(y, x, 0);
               transform.position = p;
               
               // Rotate the target GamObject
               transform.Rotate(new Vector3(0, 90, 90) * Time.deltaTime);
         }
}
