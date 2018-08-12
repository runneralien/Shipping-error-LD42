using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPileRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.Rotate(0, Random.Range(0, 180), 0, Space.Self);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
