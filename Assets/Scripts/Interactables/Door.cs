using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            promptMessage = "Press E to close door";
        }
        else
        {
            promptMessage = "Press E to open door";
        }
    }

    protected override void Interact()
    {
        isOpen = !isOpen;

        door.GetComponent<Animator>().SetBool("IsOpen", isOpen);
    }
}
