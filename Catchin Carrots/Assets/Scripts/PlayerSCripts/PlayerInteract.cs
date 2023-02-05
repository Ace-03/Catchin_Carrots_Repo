using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask objectMask;
    [SerializeField]
    private LayerMask carrotMask;
    private PlayerUI playerUI;
    public Transform jail;

    public void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    public void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, objectMask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        } else if(Physics.Raycast(ray, out hitInfo, distance, carrotMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitInfo.transform.position = jail.position;
                    interactable.BaseInteract();
                }
            }
        }
    }
}
