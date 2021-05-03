using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public Enemy skelet;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.LookAt(skelet.transform);
    }
}
