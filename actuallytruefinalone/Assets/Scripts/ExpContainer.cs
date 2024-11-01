using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ExpContainer : MonoBehaviour
{
    public SimpleFloatData EXPData;
     
    public void IncreaxeExp(float amount)
        {
            EXPData.UpdateValue(amount);
        }
}