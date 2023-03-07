using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DestroyOnTrigger : MonoBehaviour
{
    [SerializeField] private int redCubeLayerNo;
    [SerializeField] private int blueCubeLayerNo;

    public event EventHandler onCubeMiss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == redCubeLayerNo || other.gameObject.layer == blueCubeLayerNo)
        {
            onCubeMiss?.Invoke(this, EventArgs.Empty);
            Destroy(other.gameObject);
        }
    }
}
