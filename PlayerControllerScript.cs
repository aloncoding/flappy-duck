using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D duckBody;
    public float flapStrength;
    public LogicManagerScript logic;
    bool duckIsAlive = true;
    private Playercontrols playercontrols;

    private void Awake()
    {
        playercontrols = new Playercontrols();
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    private void Update()
    {
        if (playercontrols.environment.flap.triggered && duckIsAlive)
        {
            Debug.Log("Jump");
            duckBody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        duckIsAlive = false;
    }
