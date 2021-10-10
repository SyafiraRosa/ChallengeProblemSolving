using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject milk;
    public GameObject cereal;
    public GameObject chocobar;
    public GameObject grapesoda;
    public GameObject potatochip;
    public GameObject extraBallPowerup;
    public int numberOfBricksToStart;
    public int level;
    public List<GameObject> bricksInScene;
    public List<GameObject> ballsInScene;
    private ObjectPool objectPool;
    public int numberOfExtraBallsInRow = 0;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        level = 1;
        int numberOfBricksCreated = 0;

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int brickToCreate = Random.Range(0, 7);
            if (brickToCreate == 0)
            {
                bricksInScene.Add(Instantiate(milk, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 1)
            {
                bricksInScene.Add(Instantiate(cereal, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 2)
            {
                bricksInScene.Add(Instantiate(chocobar, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 3)
            {
                bricksInScene.Add(Instantiate(grapesoda, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 4)
            {
                bricksInScene.Add(Instantiate(potatochip, spawnPoints[i].position, Quaternion.identity));
            }
            else if (brickToCreate == 5 && numberOfExtraBallsInRow == 0)
            {
                bricksInScene.Add(Instantiate(extraBallPowerup, spawnPoints[i].position, Quaternion.identity));
                numberOfExtraBallsInRow++;
            }
        }

        numberOfExtraBallsInRow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceBricks()
    {
        level++;
        foreach (Transform position in spawnPoints)
        {
            int brickToCreate = Random.Range(0, 6);
            if (brickToCreate == 0)
            {
                GameObject brick = objectPool.GetPooledObject("milk");
                bricksInScene.Add(brick);
                if(brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 1)
            {
                GameObject brick = objectPool.GetPooledObject("cereal");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 2)
            {
                GameObject brick = objectPool.GetPooledObject("chocobar");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 3)
            {
                GameObject brick = objectPool.GetPooledObject("grapesoda");
                bricksInScene.Add(brick);
                if(brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 4)
            {
                GameObject brick = objectPool.GetPooledObject("potatochip");
                bricksInScene.Add(brick);
                if (brick != null)
                {
                    brick.transform.position = position.position;
                    brick.transform.rotation = Quaternion.identity;
                    brick.SetActive(true);
                }
            }
            else if (brickToCreate == 5 && numberOfExtraBallsInRow == 0)
            {
                GameObject ball = objectPool.GetPooledObject("Extra Ball Powerup");
                bricksInScene.Add(ball);
                if (ball != null)
                {
                    ball.transform.position = position.position;
                    ball.transform.rotation = Quaternion.identity;
                    ball.SetActive(true);
                }
                numberOfExtraBallsInRow++;
            }
        }
        
        numberOfExtraBallsInRow = 0;
    }
}
