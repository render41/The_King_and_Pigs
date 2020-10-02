using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class PlayerController : MonoBehaviour
{
    #region Variables
    protected Rigidbody2D rb2d;
    protected Animator anim;
    [Header("Speed Player")]
    [SerializeField] [Range(0.8f, 2.0f)] private float speed = 0.8f;
    
    [Header("Config Jump Player")]
    [Space]
    [SerializeField][Range(2.0f, 5.0f)] private float jumpForce = 2.0f;
    [SerializeField] private Transform jumpPos1;
    [SerializeField] private Transform jumpPos2;
    [SerializeField] private LayerMask detectGround;
    private float distance = 0.14f;

    [Header("Config Attack Player")]
    [Space]
    [SerializeField] private GameObject atkPoint;
    private float startTimeAtk = 0.3f;
    private float timeAtk = 0.0f;
    #endregion

    #region Mono
    private void Awake() {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
    }

    private void Update() {
        JumpPlayer();
        AttackPlayer();
        
    }

    private void FixedUpdate() {
        MovementPlayer();
    }
    #endregion

    #region Movement Player
    private void MovementPlayer(){
        var move = Input.GetAxis("Horizontal");
        this.rb2d.velocity = new Vector2(move*this.speed, this.rb2d.velocity.y);
        if(move > 0){
            this.anim.SetBool("isRun", true);
            this.transform.eulerAngles = new Vector2(0,0);
        } else if(move < 0){
            this.anim.SetBool("isRun", true);
            this.transform.eulerAngles = new Vector2(0,180);
        } else if(move == 0){
            this.anim.SetBool("isRun", false);
        }
    }
    #endregion

    #region Jump Player
    private void JumpPlayer(){
        var rayJump = Physics2D.Raycast(this.jumpPos1.position, Vector2.down, this.distance, this.detectGround)
        || Physics2D.Raycast(this.jumpPos2.position, Vector2.down, this.distance,this.detectGround);
        //Debug.DrawRay(this.jumpPos1.position, Vector2.down*this.distance, Color.black);
        //Debug.DrawRay(this.jumpPos2.position, Vector2.down*this.distance, Color.black);

        if(Input.GetKeyDown(KeyCode.Z) && rayJump){
            this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0);
            this.rb2d.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
        }

        if(rayJump){
            this.anim.SetBool("isJump", false);
        } else if(!rayJump){
            this.anim.SetBool("isJump", true);
        }
    }
    #endregion

    #region Attack Player
    private void AttackPlayer(){
        this.timeAtk-=Time.deltaTime;
        if(this.timeAtk <= 0){
            this.anim.SetBool("isAtk", false);
            this.atkPoint.SetActive(false);
            if(Input.GetKeyDown(KeyCode.X)){
                this.timeAtk = this.startTimeAtk;
                this.anim.SetBool("isAtk", true);
                this.atkPoint.SetActive(true);
            }
        }
    }
    #endregion
}
