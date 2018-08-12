using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {
    public delegate void SpawnAction();
    public static event SpawnAction BlockSpawned;
    public static event SpawnAction BadBlockSpawned;
    public GameObject[] spawnList;
    public float spawnInterval = 1;
    GameObject currentBlock;
    float currentSpawnTimer = 0;
    bool gameOverBool = false;
    public GameObject warningCanvas;
    CanvasGroup warningCanvasGroup;
    public bool currentBlockGood = true;
	// Use this for initialization
	void Start ()
    {
        warningCanvasGroup = warningCanvas.GetComponent<CanvasGroup>();
        ScoreManager.GameOver += GameOverFunc;
        GameManager.GameReset += GameResetFunc;
        warningCanvasGroup.alpha = 0;
	}
    void GameOverFunc()
    {
        gameOverBool = true;
   
    }
    void GameResetFunc()
    {
        gameOverBool = false;
    }
    void SpawnRandomBlock()
    {
        GameObject blockToSpawn = spawnList[Random.Range(0, spawnList.Length)];
        currentBlock = Instantiate(blockToSpawn, gameObject.transform.position, gameObject.transform.rotation);
        if (currentBlock.GetComponent<BuildingInput>().good == false)
        {
            warningCanvasGroup.alpha = 1;
            if (BadBlockSpawned != null)
            {
                BadBlockSpawned();
            }
            
        }
        else
        {
            warningCanvasGroup.alpha = 0;
            if(BlockSpawned != null)
            {
                BlockSpawned();
            }
            
        }
    }
	// Update is called once per frame
	void Update ()
    {
        if(currentBlock != null)
        {
            if (currentBlock.GetComponent<BuildingInput>().good == false)
            {
                warningCanvasGroup.alpha = 1;
            }
            else
            {
                warningCanvasGroup.alpha = 0;
            }
        }

        currentSpawnTimer += Time.deltaTime;
        if (currentBlock == null && gameOverBool != true)
        {
            SpawnRandomBlock();
            currentSpawnTimer = 0;
        }
	}
}
