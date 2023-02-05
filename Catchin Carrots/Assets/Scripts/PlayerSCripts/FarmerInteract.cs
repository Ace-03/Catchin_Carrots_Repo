using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FarmerInteract : MonoBehaviourPun
{
    
    public Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask objectMask;
    [SerializeField]
    private LayerMask carrotMask;
    public float Timer = 10f;    

    public void Start()
    {
    }

    public void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            GameManager.instance.photonView.RPC("CarrotsWins", RpcTarget.All);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, objectMask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                //PlayerUI.instance.UpdateText(interactable.promptMessage);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.collider.GetComponent<PhotonView>().RPC("Interact", RpcTarget.All);
                }
            }
        } else if(Physics.Raycast(ray, out hitInfo, distance, carrotMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                //PlayerUI.instance.UpdateText(interactable.promptMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //hitInfo.transform.position = jail.position;
                    hitInfo.collider.GetComponent<PhotonView>().RPC("TeleportPlayer",  RpcTarget.All,new Vector3(0, 50, 0));
                    GameManager.instance.CarrotsCaught++;
                    GameManager.instance.CheckWinCondition();
                    interactable.BaseInteract();
                }
            }
        }
        Debug.Log(hitInfo.collider);

    }
}
