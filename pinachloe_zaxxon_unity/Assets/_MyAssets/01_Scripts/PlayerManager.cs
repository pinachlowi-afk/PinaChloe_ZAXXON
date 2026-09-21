using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float lateralSpeed;
    InputActions inputActions;
    float moveX;
    float moveY;
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

    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * lateralSpeed * moveX * Time.deltaTime);
        transform.Translate(Vector3.up * lateralSpeed * moveY * Time.deltaTime);
    }
   
}
