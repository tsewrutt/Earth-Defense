using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretButtonSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject turretPrefab; // Assign the turret prefab in the Inspector
    public Button b1;
    public TurretPlacement tp;

    private void Start()
    {
        b1.onClick.AddListener(SendPrefab);
    }


    private void SendPrefab()
    {
        // When the button is clicked, set the selected turret to the prefab assigned in the Inspector
       tp.SelectPrefab(turretPrefab);
    }
}
