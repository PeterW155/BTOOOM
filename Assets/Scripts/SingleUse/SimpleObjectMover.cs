using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleObjectMover : MonoBehaviourPun, IPunObservable
{

    [SerializeField]
    private float _moveSpeed = 1f;
    [SerializeField]
    private float _cameraSpeed = 1f;

    public Camera camera;

    private CharacterController characterController;
    //private Rigidbody rigidbody;

    //private Animator _animator;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }*/
    }

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        //rigidbody = GetComponent<Rigidbody>();

        if (base.photonView.IsMine)
        {
            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(true);
            }
            //GetComponent<CharacterController>().enabled = true;

        }

    }

    private void Update()
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
    }

    /*private void UpdateMovingBoolean(bool moving)
    {
        //_animator.SetBool("Moving", moving);
    }*/
}
