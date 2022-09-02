using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{

    public GameObject bola;
    private Vector3 offset = new Vector3(30, 70, -2);

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(bola.transform.position);
        transform.position = bola.transform.position + offset;
        //transform.rotation = Quaternion.Euler(bola.transform.rotation.x, bola.transform.rotation.y, bola.transform.rotation.z);
        //transform.rotation = bola.transform.rotation;
        transform.rotation = Quaternion.Euler(56, -88, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Offset the camera so it moves from a small distance
        transform.position = bola.transform.position + offset;
       // transform.rotation = bola.transform.rotation;
        //transform.rotation = Quaternion.Euler(bola.transform.rotation.x, bola.transform.rotation.y, bola.transform.rotation.z);
        transform.rotation = Quaternion.Euler(56, -88, 3);
    }
}