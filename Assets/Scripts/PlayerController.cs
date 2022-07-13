using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CreatureAnimator playerAnimator;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float playerSpeed = 0;
    private GameMode gameMode = GameMode.None;

    public PlayerDestructable playerDestructable;
    public Damager damager;

    public GameMode GameMode { get => gameMode; set => gameMode = value; }

    private void Awake()
    {
        playerDestructable.Health = settings.health;
        playerDestructable.OnPlayerDie += StopMooving;
        damager.Damage = settings.damage;
        playerSpeed = settings.speed;
    }
    void Update()
    {
        if (gameMode == GameMode.Play)
        {
            Movement();

            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.Attack();
            }
        }
    }
    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        rb.MoveRotation(rb.rotation* Quaternion.Euler(rotation));
    }

    private void Movement()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movementHorizontal = transform.right * xMovement;
        Vector3 movementVertical = transform.forward * zMovement;

        Vector3 movementVelocity = (movementHorizontal + movementVertical).normalized * playerSpeed;

        Move(movementVelocity);

        float yRotation = Input.GetAxis("Mouse X");
        Vector3 rotationVector = new Vector3(0,yRotation,0)* settings.lookSensetivity;

        Rotate(rotationVector);
    }
    private void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
        playerAnimator.Run(velocity.magnitude);
    }
    private void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }
    public void StopMooving()
    {
        gameMode = GameMode.None;
        velocity = Vector3.zero;
    }
}
