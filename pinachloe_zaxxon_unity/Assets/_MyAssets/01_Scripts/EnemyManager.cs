using UnityEngine;

public class EnemyManager : MonoBehaviour
    
{
    //LA VELOCIDAD DE MOVIMIENTO QUE LA OBTENDRA DEL JUGADOR
    float mySpeed;
    [SerializeField] float playerSpeed;
    //componente del jugador
    [SerializeField] PlayerManager playerManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //para acceder al objeto que tiene el componente playermanager
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //una vez accedido a su objeto, accedemos a su componenete
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //me muevo a la velocidad del player
        playerSpeed = playerManager.speed + mySpeed;
        transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
