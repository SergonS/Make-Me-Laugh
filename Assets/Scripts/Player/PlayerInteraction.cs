using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private StarterAssetsInputs inputManager;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Create ray at center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.white);

        // Variable used to store collision information.
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.interact)
                {
                    interactable.BaseInteract();

                    inputManager.interact = false;  
                }
            }
        }

    }
}
