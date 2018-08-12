using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGrid : MonoBehaviour {
    public int gridSize;
    public GridSection[,] grid;
    public GameObject markerSquare;
    public GameObject floorOccupiedMarker;
    public GameObject floorVisual;

	// Use this for initialization
	void Start ()
    {
        grid = CreateGrid(gridSize, transform.position);
        GameManager.GameReset += ResetGrid;
        DrawFloor();
	}
    // creates grid of gridsections based on gridsize
	GridSection[,] CreateGrid (int gridSize,Vector3 position)
    {
        GridSection[,] grid = new GridSection[gridSize, gridSize];
        Vector3 bottomLeft = new Vector3(position.x - gridSize / 2f, position.y - gridSize / 2f);
        for(int x = 0; x<gridSize; x++)
        {
            for(int y = 0; y<gridSize; y++)
            {
                grid[x, y] = new GridSection(new Vector3(bottomLeft.x+x+0.5f,0,bottomLeft.y+y+0.5f));
            }
        }
        return grid;
    }
    void DrawFloor()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject newFloor = Instantiate(floorVisual,grid[x,y].position,Quaternion.Euler(90,0,0));
            }
        }
    }
    void DrawIndicators()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GridSection currentSquare = grid[x, y];
                if(currentSquare.overHead == true && currentSquare.occupied != true&& currentSquare.currentIndicator == null)
                {
                    currentSquare.currentIndicator = Instantiate(markerSquare, grid[x, y].position + (Vector3.up *1.2f), Quaternion.Euler(90, 0, 0));
                }
                if (currentSquare.overHead == true && currentSquare.occupied == true && currentSquare.currentIndicator == null)
                {
                    currentSquare.currentIndicator = Instantiate(floorOccupiedMarker, grid[x, y].position + (Vector3.up * 1.2f), Quaternion.Euler(90, 0, 0));
                }
                if(currentSquare.overHead == false)
                {
                    Destroy(currentSquare.currentIndicator);
                }
            }
        }
    }
    void ResetGrid()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Destroy(grid[x, y].currentOccupant);
                grid[x, y].occupied = false;
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        DrawIndicators();
	}

}
