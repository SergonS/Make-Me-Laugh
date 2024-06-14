using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddybear : Interactable
{
    [SerializeField]
    Inventory playerInventory;

    bool collected;

    public AudioSource teddy;

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        promptMessage = "Press E to collect Teddy Bear";
        collected = false;

        renderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        

        if (collected)
        {
            teddy.Play();

            collected = false;
        }
    }

    protected override void Interact()
    {
        if (!collected)
        {
            playerInventory.UpdateBearCounter();

            collected = true;

            renderer.enabled = false;

            promptMessage = string.Empty;
        }        
    }
}
