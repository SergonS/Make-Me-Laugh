using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public EnemyAI monsterScript;
    public Transform monsterTransform;
    bool interactable, hiding;
    public float loseDistance;
    private StarterAssetsInputs inputManager;


    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        hiding = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable)
        {
            if (inputManager.interact)
            {
                hideText.SetActive(false);
                hidingPlayer.SetActive(true);

                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);

                if (distance > loseDistance)
                {
                    if (monsterScript.IsChasing)
                    {
                        monsterScript.stopChase();
                    }
                } 
                
                stopHideText.SetActive(true);

                hiding = true;

                normalPlayer.SetActive(false);
                interactable = false;
            }
        }

        if (hiding)
        {
            if (inputManager.interact)
            {
                stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}
