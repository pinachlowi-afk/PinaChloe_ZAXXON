using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float lateralSpeed;
    InputActions inputActions;
    float moveX;
    float moveY;

    float rotation;
    [SerializeField] float rotationSpeed;
    float myLimit = 10f;
    float mylimity = 10f;

    InputActions player;

    Vector3 velocity;

    Vector3 currentRot;
    float maxRotationX = 45f;
    float maxRotationZ = 45f;
    [SerializeField] float smoothTime = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Shoot()
    {

        print("BOMBOCLAT");
    }
    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.player.Shoot.started += _ => Shoot();
        inputActions.player.MoveX.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.player.MoveX.canceled += ctx => moveX = 0f;
        inputActions.player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.player.MoveY.canceled += ctx => moveY = 0f;
        inputActions.player.Rotate.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.player.Rotate.canceled += _ => rotation = 0f;
        maxRotationX = 45f;
        maxRotationZ = 45f;
        smoothTime = 0.2f;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    // Update is called once per frame

    void Update()
    {
        Rotacion();
        MovePlayer();
       
    }
    void Rotacion()
    {
        transform.Rotate(Vector3.forward * rotation * rotationSpeed * Time.deltaTime * -360);
        Vector3 vectorRotZ = Vector3.forward * -maxRotationZ * moveX;
        Vector3 vectorRotX = Vector3.right * -maxRotationX * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }

    void MovePlayer()
    {
        if ( CheckPosition(myLimit) == true)
        {
            transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime, Space.World);
        }

        if (CheckPositionY(mylimity) == true)
        {

            transform.Translate(Vector3.up * lateralSpeed * moveY * Time.deltaTime, Space.World);
        }
    }
    bool CheckPosition(float myLimit)
    {
        bool inLimit;
        float posX = transform.position.x;
        if (posX > myLimit && moveX > 0)
        {
            //transform.position = new Vector3(myLimit, 0, 0);
            inLimit = false;
        }
        else if (posX < -myLimit && moveX < 0)
        {
           //transform.position = new Vector3(-myLimit, 0, 0);
            inLimit = false;
        }
        else
        {
            inLimit = true;                                                                                                                                                                                                                                                                                           
        }
        return inLimit;

        
       
    }
    bool CheckPositionY(float mylimity)
    {
        bool inLimit;
        float posY = transform.position.y;
        if (posY > mylimity && moveY > 0)
        {
           // transform.position = new Vector3(0, -mylimity, 0);
            inLimit = false;
        }
        else if (posY < -mylimity && moveY < 0)
        {
           
            inLimit = false;
        }
        else
        {
            inLimit = true;
        }
        return inLimit;
    }


    }
