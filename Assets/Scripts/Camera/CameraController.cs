using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    private GameObject player;
    private Vector3 newPos;
    private float timeSpeed = 0.05f;
    [Header("Camera Position")]
    [SerializeField][Range(-1.0f, 1.0f)] private float offsetCameraX;
    [SerializeField][Range(-1.0f, 1.0f)] private float offsetCameraY;
    #endregion

    #region Mono
    private void Awake() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        CameraPosition();
    }
    #endregion

    #region Camera Position
    private void CameraPosition(){
        this.newPos = new Vector3(this.player.transform.position.x + this.offsetCameraX, this.player.transform.position.y+ this.offsetCameraY, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, this.newPos, this.timeSpeed);
    }
    #endregion
}
