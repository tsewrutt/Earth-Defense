using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TurretButtonSelection : MonoBehaviour
{

    // Start is called before the first frame update
    public bool btnClick = false;
    public GameObject turretPrefab; // Assign the turret prefab in the Inspector
    public Button b1;
    public TurretPlacement tp;

    //TOOL TIP
     public ToolTipScript tts;

    private void Start()
    {

        b1.onClick.AddListener(SendPrefab);
   

    }


    private void SendPrefab()
    {
        btnClick = true;
        // When the button is clicked, set the selected turret to the prefab assigned in the Inspector
       tp.SelectPrefab(turretPrefab);
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Inside box"); // bizare but kinda works, maybe do a fakebox collider inside the tile map
            tts.ShowTooltip();
/*            if (Input.GetMouseButtonDown(0))
            {

            }*/
        }
        else
        {
            tts.HideTooltip();
        }
    }

  /*  public void OnPointerEnter(PointerEventData ed)
    {
        tts.ShowTooltip();
    }
    public void OnPointerExit(PointerEventData ed)
    {
        tts.HideTooltip();
    }*/




}
