using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    GameObject floorGrid;
    GroundGrid gridScript;
    GridSection currentOver;
    GridSection previousOver;
    public GameObject groundBuilding;
    ScoreManager scoreManager;
    public GameObject explosionEffect;
    public delegate void CollideAction();
    public static event CollideAction Collided;
    // Use this for initialization
    void Start ()
    {
        floorGrid = GameObject.Find("GroundGrid");
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public GridSection SectionFromWorldPoint(Vector3 position,GridSection[,] grid,int gridSize)
    {
        
        float percentX = (position.x + gridSize / 2f) / gridSize;
        float percentY = (position.z + gridSize / 2f) / gridSize;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.RoundToInt((gridSize - 1) * percentX);
        int y = Mathf.RoundToInt((gridSize - 1) * percentY);
        return grid[x, y];
    }

    void LockPosition(GridSection sectionToLock)
    {
        sectionToLock.overHead = false;
        sectionToLock.occupied = true;
        GameObject building = Instantiate(groundBuilding, sectionToLock.position, transform.rotation);
        sectionToLock.currentOccupant = building;
        StationaryBlockBehaviour buildingScript = building.GetComponent<StationaryBlockBehaviour>();
        buildingScript.CurrentSection = sectionToLock;
        Destroy(gameObject);
    }
    void buildingCollide(GridSection spotToCollide)
    {
        spotToCollide.occupied = false;
        spotToCollide.overHead = false;
        if(spotToCollide.currentOccupant.GetComponent<StationaryBlockBehaviour>().Good == true)
        {
            scoreManager.Score -= 1;
            scoreManager.Lives -= 1;
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(spotToCollide.currentOccupant);
        if(Collided != null)
        {
            Collided();
        }
        Destroy(gameObject);
    }
    void Update ()
    {
        GroundGrid gridScript = floorGrid.GetComponent<GroundGrid>();
        if (gridScript.grid != null)
        {
            currentOver = SectionFromWorldPoint(transform.position, gridScript.grid, gridScript.gridSize);
            if(previousOver != currentOver)
            {
                if(previousOver != null)
                {
                    previousOver.overHead = false;
                }
                previousOver = currentOver;
                
            }
            currentOver.overHead = true;

            

            if(transform.position.y - currentOver.position.y < 0.5 && currentOver.occupied == false)
            {
                LockPosition(currentOver);
            }
            else if(transform.position.y - currentOver.position.y < 1 && currentOver.occupied == true)
            {
                buildingCollide(currentOver);
            }
        }
        


    }
}
