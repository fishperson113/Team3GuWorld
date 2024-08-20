using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    [SerializeField] private PortalDoor linkedPortal; 

    private bool canTeleport = true; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (linkedPortal != null && canTeleport)
        {
            Teleport(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = true;
    }
    private void Teleport(Transform player)
    {
        linkedPortal.canTeleport = false;

        player.position = linkedPortal.transform.position;
    }
}
