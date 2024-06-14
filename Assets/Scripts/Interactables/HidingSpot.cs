using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : Interactable
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform enterZone;

    [SerializeField]
    private Transform exitZone;

    private bool isHiding;

    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHiding)
        {
            promptMessage = "Press E to get out of hiding";
        }
        else
        {
            promptMessage = "Press E to hide";
        }
    }

    protected override void Interact()
    {
        if (isHiding)
        {     
            player.transform.position = enterZone.position;
            player.transform.rotation = enterZone.rotation;
        }
        else
        {
            player.transform.position = exitZone.position;
            player.transform.rotation = exitZone.rotation;
        }

        isHiding = !isHiding;
    }
}
