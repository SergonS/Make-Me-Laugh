using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int bears;
    [SerializeField]
    int totalBears;

    [SerializeField]
    private TextMeshProUGUI total;

    // Start is called before the first frame update
    void Start()
    {
        bears = 0;
        totalBears = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBearCounter()
    {
        bears += 1;

        total.text = bears.ToString();
    }
}
