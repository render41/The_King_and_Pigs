using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Variables
    [SerializeField] protected float speedBall;
    protected float timeLive = 4.0f;
    #endregion

    #region Mono
    private void Update() {
        MovementBall();
        LiveBall();
    }
    #endregion

    #region Movement Ball
    private void MovementBall(){
        this.transform.Translate(Vector2.left*this.speedBall*Time.deltaTime);
    }
    #endregion

    #region Live Ball
    private void LiveBall(){
        this.timeLive -= Time.deltaTime;
        if(this.timeLive <= 0.0f){
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region Trigger's
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PointAtk"){
            Destroy(this.gameObject);
        }
    }
    #endregion
}
