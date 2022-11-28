using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetActive : MonoBehaviourPun, IPunObservable
{

    public GameObject camera;
    public GameObject orientation;

    //this was all originally copied from the SimpleObjectMover script so if anything goes wrong try looking at that
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
    }

    private void Awake()
    {

        if (base.photonView.IsMine)
        {
            camera.SetActive(true);
            orientation.SetActive(true);
            this.gameObject.tag = "Player";
            /*foreach(Transform t in this.transform)
            {
                t.tag = "Player";
            }*/
            /*foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(true);
            }*/

        }

    }

    /*private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, 0.0f, y)) * _moveSpeed;
            characterController.SimpleMove(new Vector3(x * _moveSpeed, 0.0f, y * _moveSpeed));

            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;


            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector4(transform.localRotation.x, mouseX * 360f, transform.localRotation.z));
            camera.transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), transform.localRotation.y, transform.localRotation.z));

            //UpdateMovingBoolean((x != 0f || y != 0f));
        }
    }*/
}
