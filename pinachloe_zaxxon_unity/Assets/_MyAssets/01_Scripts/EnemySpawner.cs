using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //prefab que voy a spawnear
    [SerializeField] GameObject[] enemies;
    //intervalo de tiempo para spawnear
    [SerializeField] float interval = 0.5f;
    // limites aleatorios de los ejes x e y
     float limitX = 15F;
     float limitUp = 15F;
     float limitDown = -15F;

    // enemigos intermedios distancia a la que sale el primer enemigo
    float firstenemyDistance;
    float distanceBetweenEnemies;
    //oleadas o bucles de enemigos, int es un num entero
    [SerializeField] float waves;
    [SerializeField] PlayerManager playerManager;









    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceBetweenEnemies = 10f;
        firstenemyDistance = 50f;

        StartCoroutine("SpawnEnemy");
        EnemigosIntermedios();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int n = 0; n < waves; n++)
            {
                SacarMeteoros(0);
            }

            interval = distanceBetweenEnemies / playerManager.speed;
            yield return new WaitForSeconds(interval);
        }
    
    }

    void EnemigosIntermedios()
    {
        float distanceToFill = transform.position.z - firstenemyDistance;
        float numberOfEnemiesf = distanceToFill / distanceBetweenEnemies;
        int ciclos = Mathf.FloorToInt(numberOfEnemiesf);
        for (int i = 0; i < ciclos; i++)
        {
            SacarMeteoros(distanceToFill);
            distanceToFill -= distanceBetweenEnemies;
        }
    }
    void SacarMeteoros(float distanceZ)
    {
        float randomX = Random.Range(-limitX, limitX);
        float randomY = Random.Range(limitDown, limitUp);
        // instanciamos en posicion aleatoria en x e y pero en z donde esta el spawner
         Vector3 instPos = new Vector3(randomX, randomY,transform.position.z - distanceZ);
        int r = Random.Range(0, enemies.Length);
        Instantiate(enemies[r], instPos, Quaternion.identity);
      
      

    }
}

