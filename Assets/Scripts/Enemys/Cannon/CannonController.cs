using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class CannonController : MonoBehaviour
{
    #region Variables
    protected Animator anim;
    [SerializeField] protected LayerMask layerPlayer;
    [SerializeField][Range(-1.0f, 1.0f)] protected float finalDistance;
    #endregion

    #region Mono
    private void Awake() {
        this.anim = GetComponent<Animator>();
    }
    private void Update() {
        ShootCannon();
    }
    #endregion

    #region Shoot Cannon
    private void ShootCannon(){
        var posCannon = this.gameObject.transform.position;
        var lineHit = Physics2D.Linecast(posCannon, new Vector2(posCannon.x * this.finalDistance,posCannon.y), this.layerPlayer);
        //Debug.DrawLine(posCannon, new Vector2(posCannon.x * this.finalDistance,posCannon.y), Color.black);

        if(lineHit){
            SpawnBall.instanceSpawnBall.SpawnBallCannon(true);
            if(SpawnBall.instanceSpawnBall.isAnimationActive == true){
                this.anim.SetBool("isShoot", true);
            }
        }
        if(!lineHit){
            this.anim.SetBool("isShoot", false);
        }
    }
    #endregion
}
