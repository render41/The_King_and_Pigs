using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpriteController : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject dialogueKey;
    #endregion

    #region Trigger's
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.dialogueKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            this.dialogueKey.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    #endregion
}
