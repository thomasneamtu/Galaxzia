using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player player;
    [SerializeField] private Enemy bomberPrefab;
    [SerializeField] private Enemy tankPrefab;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private List<Enemy> listOfAllEnemiesAlive;

    [SerializeField] private Animator deathCameraAnimation;
    [SerializeField] private float camSpeed;
    [SerializeField] private GameObject virtualCam;
    [SerializeField] private Vector3 targetCamPosition;

    private ScoreManager scoreManager;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        listOfAllEnemiesAlive = new List<Enemy>();

        scoreManager = GetComponent<ScoreManager>();
        
        FindObjectOfType<Player>().healthValue.OnDied.AddListener(GameOver);

        SpawnEnemy();
        StartCoroutine(SpawnWaveOfEnemies());
        StartCoroutine(SpawnWaveofTanks());
        deathCameraAnimation.SetBool("isDead", false);
        Debug.Log("The Game Begins!");
        Debug.Log("GameManager is Here!");
    }
   
    private void GameOver()
    {  
        OnGameOver.Invoke();
        StopAllCoroutines();
        deathCameraAnimation.SetBool("isDead", true);
        DeathCameraMovement();

        Debug.Log("Game is Over!");
    }

    private void DeathCameraMovement()
    {
       virtualCam.transform.position = Vector3.Lerp(transform.position, targetCamPosition, Time.deltaTime * camSpeed);
    }

    private Enemy SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPointsArray.Length);
        Transform randomSpawnPoint = spawnPointsArray[Random.Range(0, spawnPointsArray.Length)];

        Enemy enemyClone = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        listOfAllEnemiesAlive.Add(enemyClone);
        return enemyClone;
        //enemyClone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
    }

    private Enemy SpawnTank()
    {
        int randomIndex = Random.Range(0, spawnPointsArray.Length);
        Transform randomSpawnPoint = spawnPointsArray[Random.Range(0, spawnPointsArray.Length)];

        Enemy enemyTank = Instantiate(tankPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        listOfAllEnemiesAlive.Add(enemyTank);
        return enemyTank;
        //enemyClone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
    }

    private Enemy SpawnBomber()
    {
        int randomIndex = Random.Range(0, spawnPointsArray.Length);
        Transform randomSpawnPoint = spawnPointsArray[Random.Range(0, spawnPointsArray.Length)];

        Enemy enemyBomber = Instantiate(bomberPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        listOfAllEnemiesAlive.Add(enemyBomber);
        return enemyBomber;
        //enemyClone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
    }

    public void RemoveEnemyFromList(Enemy enemyToBeRemoved)
    {
        scoreManager.IncreaseScore(ScoreType.EnemyKilled);
        listOfAllEnemiesAlive.Remove(enemyToBeRemoved);
        
        /*
         for(int index = 0; index < listOfAllEnemiesAlive.Count; index++ )
        {
            if(listOfAllEnemiesAlive[index] == null)
            {
                listOfAllEnemiesAlive.RemoveAt(index);
            }
        }
        */
    }

    private IEnumerator SpawnWaveOfEnemies()
    {
        while (true)
        {
            if (listOfAllEnemiesAlive.Count < 50) //enemies are less than 50
            {
                Enemy clone = SpawnEnemy();
                Enemy bomber = SpawnBomber();
                //yield return new WaitForEndOfFrame();
                //clone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
            }

            yield return new WaitForSeconds(Random.Range(1, 4));
    
        }
    }


    private IEnumerator SpawnWaveofTanks()
    {
        while (true)
        {
            if (listOfAllEnemiesAlive.Count < 50) //enemies are less than 20
            {
               Enemy Tank = SpawnTank();
                //yield return new WaitForEndOfFrame();
                //clone.healthValue.OnDied.AddListener(RemoveEnemyFromList);
            }

            yield return new WaitForSeconds(Random.Range(10, 15));

        }
    }
}
