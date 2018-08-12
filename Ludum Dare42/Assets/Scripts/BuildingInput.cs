using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInput : MonoBehaviour {
    GameObject floorGrid;
    GroundGrid floorGridScript;
    public float dropSpeed;
    //denotes number of blocks away from center
    int currentGridPositionX;
    int currentGridPositionY;
    public int rightBlocks;
    public int leftBlocks;
    public int upBlocks;
    public int downBlocks;
    public bool good;
    int gridSize;
	void Start ()
    {
        floorGrid = GameObject.Find("GroundGrid");
        floorGridScript = floorGrid.GetComponent<GroundGrid>();
        gridSize = floorGridScript.gridSize;
        currentGridPositionX = gridSize / 2;
        currentGridPositionY = gridSize / 2;
        
    }
	void RotateClockWise()
    {
        int storedRight = rightBlocks;
        int storedDown = downBlocks;
        int storedLeft = leftBlocks;
        int storedUp = upBlocks;
        rightBlocks = storedUp;
        downBlocks = storedRight;
        leftBlocks = storedDown;
        upBlocks = storedLeft;
    }

	void Update ()
    {
        transform.Translate(Vector3.down * dropSpeed * Time.deltaTime);
        if (Input.GetKeyDown("a")||Input.GetKeyDown("left"))
        {
            if(currentGridPositionX -1 -leftBlocks >= 0)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                currentGridPositionX -= 1;
            }

        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            if(currentGridPositionX +1+rightBlocks < gridSize)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                currentGridPositionX += 1;
            }
            
            
        }
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            if(currentGridPositionY +1+upBlocks <gridSize)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                currentGridPositionY += 1;
            }
            
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            if(currentGridPositionY -1 - downBlocks >= 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                currentGridPositionY -= 1;
            }
            
        }
        if (Input.GetKeyDown("space"))
        {
            if(currentGridPositionX + upBlocks < gridSize && currentGridPositionX-downBlocks >= 0 && currentGridPositionY + leftBlocks <gridSize && currentGridPositionY-rightBlocks >=0 )
            {
                RotateClockWise();
                transform.Rotate(0f, 90f, 0f);

            }
              
        }
        if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
