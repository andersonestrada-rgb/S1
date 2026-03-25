using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public int life = 100;
    public static int score = 0;
    public string Name = "Mambo";       
    [SerializeField] protected float speed = 5.0f;

    public InputSystem_Actions inputs;
    [SerializeField] private Vector2 MoveInput;

    private void Awake()
    {
        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += OnMovement;
        inputs.Player.Move.canceled += OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {        
        MoveInput = context.ReadValue<Vector2>();
    }

    protected virtual void MovementMechanise(Vector2 input) //private void MovementMechanise(Vector2 input)
    {
        transform.position += (Vector3)input * speed * Time.deltaTime;
    }

    protected void Update()
    {
        if (MoveInput != Vector2.zero)
        {
            MovementMechanise(MoveInput);
        }
    }
}