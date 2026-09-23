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
        transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * lateralSpeed * moveY * Time.deltaTime, Space.World);
    }



}
