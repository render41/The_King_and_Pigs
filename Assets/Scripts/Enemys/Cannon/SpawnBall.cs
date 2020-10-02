using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    #region Variables
    public static SpawnBall instanceSpawnBall;
    [SerializeField] protected GameObject ballPrefab;
    protected GameObject spawnBall;
    protected float startTimeSpawn = 1.5f;
    protected float timeSpawn;
    public bool isAnimationActive;
    #endregion
    
    #region Mono
    private void Awake() {
        this.spawnBall = GetComponent<GameObject>();
        instanceSpawnBall = this;
    }
    #endregion

    #region Spawn Ball Cannon
    public virtual void SpawnBallCannon(bool _isSpawn){
        this.timeSpawn -= Time.deltaTime;
        if(this.timeSpawn <= 0.0f){
            _isSpawn = true;
            this.isAnimationActive = true;
            if(_isSpawn == true){
                this.spawnBall = Instantiate(this.ballPrefab,this.gameObject.transform.position, Quaternion.identity);
                this.timeSpawn = this.startTimeSpawn;
            }
        }
        else if(this.timeSpawn >= this.startTimeSpawn){
            _isSpawn = false;
            this.isAnimationActive = false;
        }
    }
    #endregion
}
