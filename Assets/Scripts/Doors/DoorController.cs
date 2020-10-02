using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    #region Variables
    private GameObject player;
    private bool isDoor;
    [SerializeField] private Transform goDoor;
    [SerializeField] private GameObject dialogueInterrogation;
    #endregion

    #region Mono
    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        TeleportPosition();
    }
    #endregion

    #region Teleport Position
    private void TeleportPosition(){
        if(this.isDoor && Input.GetKeyDown(KeyCode.UpArrow)){
            this.player.transform.position = this.goDoor.transform.position;
        }
    }
    #endregion

    #region Trigger's
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.isDoor = true;
            this.dialogueInterrogation.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.isDoor = false;
            this.dialogueInterrogation.SetActive(false);
        }
    }
    #endregion

}
