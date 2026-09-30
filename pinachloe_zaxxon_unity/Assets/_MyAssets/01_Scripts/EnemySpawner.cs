using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //prefab que voy a spawnear
    [SerializeField] GameObject enemy;
    //intervalo de tiempo para spawnear
    [SerializeField] float interval = 0.5f;
    // limites aleatorios de los ejes x e y
    [SerializeField] float limitX;
    [SerializeField] float limitUp;
    [SerializeField] float limitDown;

    // enemigos intermedios distancia a la que sale el primer enemigo
    float firstenemyDistance = 0;
    //oleadas o bucles de enemigos, int es un num entero
    [SerializeField] int waves;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SacarMeteoros(float distanceZ=0)
    {
        float randomX = Random.Range(-limitX, limitX);
        float randomY = Random.Range(limitDown, limitDown);
        // instanciamos en posicion aleatoria en x e y pero en z donde esta el spawner
         Vector3 depl = new Vector3(randomX, randomY, distanceZ);
        Vector3 instPos = transform.position + depl;
        Instantiate(enemy, instPos, Quaternion.identity);

    }
}

