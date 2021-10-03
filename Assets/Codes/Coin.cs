using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotation;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotation, 0));
    }
}
