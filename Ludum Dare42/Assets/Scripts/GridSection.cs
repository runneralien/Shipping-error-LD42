using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSection
{
    public Vector3 position;
    public bool occupied = false;
    public bool overHead = false;
    public GameObject currentOccupant;
    public GameObject currentIndicator;
    public GridSection(Vector3 _position)
    {
        position = _position;
    }
    

}
