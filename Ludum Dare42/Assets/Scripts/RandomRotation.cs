using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
    float rotationFactorX;
    float rotationFactorY;
    float rotationFactorZ;
    public float rotateSpeed = 1f;
	// Use this for initialization
	void Start ()
    {
        rotationFactorX = Random.Range(0f, 1f);
        rotationFactorY = Random.Range(0f, 1f);
        rotationFactorZ = Random.Range(0f, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Rotate(rotationFactorX * Time.deltaTime * rotateSpeed, rotationFactorY * Time.deltaTime * rotateSpeed, rotationFactorZ * Time.deltaTime * rotateSpeed, Space.Self);
	}
}
