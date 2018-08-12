using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSelfDestory : MonoBehaviour {

    // Use this for initialization
    int maxtime = 2;
    float currentTime;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxtime)
        {
            Destroy(gameObject);
        }
	}
}
