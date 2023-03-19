using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTipScript : MonoBehaviour
{
   
    public float tooltipDelay = 1f;  // Delay in seconds before showing the tooltip

    private bool isTooltipVisible = false;
    private float tooltipTimer = 0f;
    
    //COMES WITH A PANEL AND A TEXT
    public GameObject tooltipObject;

    void Start()
    {

    }

    public void ShowTooltip()
    {
        isTooltipVisible = true;
        tooltipTimer = tooltipDelay;
    }

    void Update()
    {
        if (isTooltipVisible)
        {
            tooltipTimer -= Time.deltaTime;
            if (tooltipTimer <= 0f)
            {
                //tooltipTextComponent.text = tooltipText;
                tooltipObject.SetActive(true);
                tooltipObject.transform.position = Input.mousePosition + new Vector3(16f, -16f, 0f);
            }
        }
        else
        {
            tooltipObject.SetActive(false);
        }
    }

    public void HideTooltip()
    {
        isTooltipVisible = false;
    }
}
