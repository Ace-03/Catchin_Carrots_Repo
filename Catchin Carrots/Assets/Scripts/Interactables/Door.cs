using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Door : Interactable
{
    public GameObject doo;
    private bool isGone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [PunRPC]
    protected override void Interact()
    {
        if(isGone == false)
        {
            isGone = true;
            doo.SetActive(false);

            Invoke("BringDoorBack", 3.0f);

        }
       /* if(isMoving == false)
        {
            StartCoroutine(OpenningDoor());
        }
       */
    }

 /*   IEnumerator OpenningDoor()
    {
        isMoving = true;
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            door.position = new Vector3(door.localPosition.x + moveInterval, door.localPosition.y, door.localPosition.z);
            yield return new WaitForSeconds(.1f);
        }
        Invoke("StartClosing", 2.0f);
    }

    public void StartClosing()
    {
        StartCoroutine(ClosingDoor());
    }

    IEnumerator ClosingDoor()
    {
        for (float i = 1; i > 0; i -= 0.1f)
        {
            door.position = new Vector3(door.localPosition.x - moveInterval, door.localPosition.y, door.localPosition.z);
            yield return new WaitForSeconds(.1f);
        }

        Invoke("NowCanOpen", 1.0f);
    }

    public void NowCanOpen()
    {
        isMoving = false;
    }
 */

    public void BringDoorBack()
    {
        doo.SetActive(true);
        Invoke("Free", 1.0f);
    }

    public void Free()
    {
        isGone = false;
    }
}
