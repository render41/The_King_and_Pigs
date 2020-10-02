using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAreaController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform initialPos;
    [SerializeField] private GameObject player;
    #endregion

    #region Mono
    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }
    #endregion

    #region Colliders
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            this.player.transform.position = this.initialPos.position;
        }
    }
    #endregion
}
