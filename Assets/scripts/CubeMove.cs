using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    private void Update()
    {
        transform.position += new Vector3(0,0,1f*speed * Time.deltaTime);
    }
}
