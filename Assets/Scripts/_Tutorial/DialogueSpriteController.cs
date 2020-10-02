using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDialogue : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject jumpKey;
    #endregion

    #region Trigger's
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.jumpKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.jumpKey.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    #endregion
}
