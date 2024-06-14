using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    private StarterAssetsInputs inputManager;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool IsOn;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<StarterAssetsInputs>();

        //IsOn = false;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOn && inputManager.flashlight)
        {
            flashlight.SetActive(true);

            //turnOn.Play();
            IsOn = true;
        }
        else if (IsOn && inputManager.flashlight)
        {
            flashlight.SetActive(false);

            //turnOff.Play();
            IsOn = false;
        }
    }
}
