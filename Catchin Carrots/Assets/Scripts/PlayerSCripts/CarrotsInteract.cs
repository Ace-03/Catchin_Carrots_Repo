using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotsInteract : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask objectMask;
    [SerializeField]
    private LayerMask FarmerMask;
    public PlayerUI playerUI;
    public Transform jail;

    public void Start()
    {
    }

    public void Update()
    {
        PlayerUI.instance.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        

        //Object Interaction
        if (Physics.Raycast(ray, out hitInfo, distance, objectMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                PlayerUI.instance.UpdateText(interactable.promptMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        }

        //Player Interaction (Run!)
        else if (Physics.Raycast(ray, out hitInfo, distance, FarmerMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                PlayerUI.instance.UpdateText(interactable.promptMessage);
            }
        }

    }
}
