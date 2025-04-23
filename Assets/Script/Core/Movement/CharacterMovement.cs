using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    internal Stats stats;
    internal Animator Animator { get; set; }
    internal CharacterController CharacterController { get; set; }
    internal Attack attack;

    [SerializeField] internal float walkSpeed = 10f;
    [SerializeField] internal float jumpHeight = 0.3f;

    // movement and input
    internal Vector2 dir = Vector2.zero;
    internal float inputDir = 0;
    internal bool rightMouse;
    internal bool leftMouse;
    internal bool jump;
    internal bool facingRight = true;
    // velocity
    internal Vector2 velocity;
    private Vector2 previousPosition;
    // state machine
    private BaseState _currentState;
    private StateFactory _stateFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = GetComponent<Animator>();
        CharacterController = GetComponent<CharacterController>();
        stats = GetComponent<Stats>();
        attack = GetComponentInChildren<Attack>();

        _stateFactory = new StateFactory();
        ChangeState("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
        CalculateVelocity();
        Gravity();

        if (stats.isDeath)
        {
            ChangeState("Die");
        }

        if (velocity.y < -1f && !stats.isDeath)
        {
            ChangeState("Glide");
        }

        _currentState?.Execute(this);

        if (stats.isDeath) return;

        CharacterController.Move(dir);
    }

    private void FlipSprite()
    {
        if (stats.isDeath) return;
        if (inputDir > 0 && !facingRight)
        {
            Flip();
        }
        if (inputDir < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        var spriteScale = transform.localScale;
        spriteScale.x *= -1;
        transform.localScale = spriteScale;

        facingRight = !facingRight;
    }

    private void CalculateVelocity()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 movement = currentPosition - previousPosition;
        velocity = Vector2.ClampMagnitude(movement / Time.deltaTime, 3);

        previousPosition = currentPosition;
    }

    private void Gravity()
    {
        if (CharacterController.isGrounded && dir.y <= 0)
        {
            dir = Vector3.zero;
            dir.y = -0.01f;
        }

        dir.y += Physics.gravity.y * 0.02f * Time.deltaTime;
    }

    internal void ChangeState(string stateName)
    {
        _currentState?.Exit(this);
        _currentState = _stateFactory.GetState(stateName);
        _currentState?.Enter(this);
    }

    internal string GetStateName()
    {
        return _currentState?.Name;
    }
}
