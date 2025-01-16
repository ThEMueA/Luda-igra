using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject[] obsticalArr;
    [SerializeField] private Transform obstacleParent;
    public float obsitcaleSpawnTime = 2f;
    private float timeUnitlSpawn;
    public float speed = 1f;
    private float _obsticalespawntime;
    private float _obsticaleSpeed;
    private float timeAlive;
    [Range(0, 1)] public float obsticleSpawnTimeFactor = 0.1f;

    [Range(0, 1)] public float obsticleSpeedTimeFactor = 0.2f;
    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        { timeAlive += Time.deltaTime;
            CalculateFactors();
            Spawnloop();
           
        }
    }
    private void CalculateFactors()
    {
        _obsticalespawntime = obsitcaleSpawnTime / Mathf.Pow(timeAlive, obsticleSpawnTimeFactor);
        _obsticaleSpeed = speed * Mathf.Pow(timeAlive, obsticleSpeedTimeFactor);
    }
    private void Start()
    {
        GameManager.Instance.OnGameOver.AddListener(clear);
        GameManager.Instance.OnPlay.AddListener(ResetTimers);
     
    }
    private void Spawnloop()
    {
        timeUnitlSpawn += Time.deltaTime;

        if (timeUnitlSpawn >= _obsticalespawntime)
        {
            Spawn();
            timeUnitlSpawn = 0;
        }
    }
        private void clear()
    {
        foreach(Transform child in obstacleParent){
            Destroy(child.gameObject);
        }



    }


    private void ResetTimers()
    {
        timeAlive = 1f;
        _obsticalespawntime = obsitcaleSpawnTime;
        _obsticaleSpeed = obsitcaleSpawnTime;

    }
    private void Spawn()
    {
        GameObject obstilcetoSpawn = obsticalArr[Random.Range(0, obsticalArr.Length)];
        GameObject spawnedObsticle = Instantiate(obstilcetoSpawn,transform.position , Quaternion.identity);
        spawnedObsticle.transform.parent = obstacleParent;
        Rigidbody2D obsticleRB = spawnedObsticle.GetComponent<Rigidbody2D>();
        obsticleRB.linearVelocity = Vector2.left * _obsticaleSpeed;
    }



    
}
