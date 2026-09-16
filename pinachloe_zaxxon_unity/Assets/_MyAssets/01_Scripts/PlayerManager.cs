using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool isAlive;
    public float speed;
    [SerializeField] float lateralSpeed;
    InputActions inputActions;
    float MoveX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Shoot()
    {

        print("BOOOOM");
            }
    private void Awake()
    {
        inputActions = new InputActions();
       ;
        inputActions.player.Shoot.started += _ => Shoot();
        inputActions.player.MoveX.performed += ctx => MoveX = ctx.ReadValue<float>();
        inputActions.player.MoveX.canceled += _ => MoveX = 0f;

    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right* lateralSpeed * Time.deltaTime);

    }
   
}
