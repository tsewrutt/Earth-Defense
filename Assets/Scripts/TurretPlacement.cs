using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TurretPlacement : MonoBehaviour
{
    public Tilemap tilemap;
    public MoneyManager mm;
    public GameObject selectedPrefab;
    public Vector2 boxMaxpt;
    public Vector2 boxMinpt;
    private Rect rect;
    //money part is working for turret placement but reward is not rn
    //only issue is money manager x enemy
    public Vector3Int prefabSize = new Vector3Int(2, 2, 0);
    //dont even need this since we have only one prefab per button click

    //Check Click Region
    public GameObject[] unclickableObjects;
    private bool checkClick;
    public void SelectPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;

    }

    private void Update()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //this part is erroneous cause turret doesnot have a spriterender
        if (selectedPrefab != null)
        {
            
            Bounds b = GrabPrefabSprite(selectedPrefab);
            b.center = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0) && selectedPrefab != null)
        {
            // Get the position of the mouse click in world space
           
            checkClick = CheckMousePosition(clickPosition);
            //Debug.Log(checkClick);
            if (checkClick)
            {
                //do nothing if we click inside of box region
                Debug.Log("box hit");
                  
            }
            else
            {
                Turret t = selectedPrefab.GetComponent<Turret>();
                if (mm.money - t.cost >= 0) //checks if player has enough money for turret
                {


                    // Convert the click position to a cell position on the Tilemap
                    Vector3Int cellPosition = tilemap.WorldToCell(clickPosition);

                    // Place the selected prefab at the cell position on the Tilemap
                    GameObject pI = Instantiate(selectedPrefab, tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity, tilemap.transform);

                    pI.transform.localScale = new Vector3(prefabSize.x * tilemap.cellSize.x, prefabSize.y * tilemap.cellSize.y, prefabSize.z * tilemap.cellSize.z);
                    pI.transform.parent = tilemap.transform;

                    mm.money = mm.money - t.cost;
                }
                else
                {
                    //do like prompt saying not sufficiant funds
                    Debug.Log("Not Enough Coins");
                }
                selectedPrefab = null;
                //sets to null for next button click
            }

            
        
        }
    }

    private void OnGUI()
    {
        GUI.Box(rect, "");
    }


    //will check if selection is valid
    //if true is return means we inside of boxes, therefore cant spawn turret
    private bool CheckMousePosition(Vector3 mousePos)
    {
        mousePos.z = 30f;
        //Bounds bounds = new Bounds(unclickableObjects[0].transform.position, Vector3.zero);
        foreach(GameObject regionObj in unclickableObjects)
        {

            SpriteRenderer spr = regionObj.GetComponent<SpriteRenderer>();
            Bounds spritebound = spr.bounds;
            
            if (spritebound.Contains(mousePos))
            {
                mousePos.z = 0f;
                return true;
            }


        }
        mousePos.z = 0f;
        return false;
    }


    private Bounds GrabPrefabSprite(GameObject go)
    {
        Transform rotatingmechTransform = go.transform.GetChild(0);
        GameObject rotatingmechgo = rotatingmechTransform.gameObject;

        Transform turretModelTransform = rotatingmechgo.transform.GetChild(0);
        GameObject turretModelgo = turretModelTransform.gameObject;

        SpriteRenderer turretSprite = turretModelgo.GetComponent<SpriteRenderer>();
        Bounds b = turretSprite.bounds;

        return b;
    }
}
