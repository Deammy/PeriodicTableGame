using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float CheckRadius;
    private Rigidbody2D Player;
    private bool facingRight = true;
    private bool Jumping = false;
    private bool Grounding;
    public float MoveDirection;
    public Transform GroundCheck;
    public Transform CeilingCheck;
    public LayerMask GroundObject;
    private Quaternion OriginalRotate;

    // Start is called before the first frame update

    void Start(){
        OriginalRotate = transform.rotation;
    }
    private void Awake(){
        Player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovementInput();
        if(MoveDirection < 0 && facingRight){
            TurnLeftRight();
        }
        else if(MoveDirection > 0 && !facingRight){
            TurnLeftRight();
        }
        AntiCollision();
    }
    private void FixedUpdate(){
        Grounding = Physics2D.OverlapCircle(GroundCheck.position,CheckRadius,GroundObject);
        Move();
    }
    void TurnLeftRight(){
        facingRight = !facingRight;
        if(facingRight){
            OriginalRotate.y = 0f;
        }
        else{
            OriginalRotate.y = 180f;
        }
        transform.rotation = OriginalRotate;
    }
    void MovementInput(){
        MoveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && Grounding){
            Jumping = true;
        }
    }
    void Move(){
        Player.velocity = new Vector2(MoveDirection * Speed,Player.velocity.y);
        if(Jumping){
            Player.AddForce(new Vector2(0f,JumpForce));
        }
        Jumping = false;
    }
    void AntiCollision(){
        transform.rotation = OriginalRotate;
    }
}
