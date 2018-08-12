using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryBlockBehaviour : MonoBehaviour {

    // Use this for initialization
    public GridSection CurrentSection;
    public bool Good = true;
    ScoreManager scoreManager;
	void Start ()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if(Good == true)
        {
            scoreManager.Score += 1;
        }
        gameObject.transform.position = CurrentSection.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
