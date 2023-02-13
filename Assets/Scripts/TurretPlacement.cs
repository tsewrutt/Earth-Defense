using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TurretPlacement : MonoBehaviour
{
    public Tilemap tilemap;
    public MoneyManager mm;
    public GameObject selectedPrefab;
    //money part is working for turret placement but reward is not rn
    //only issue is money manager x enemy
    public Vector3Int prefabSize = new Vector3Int(2, 2, 0);
    //dont even need this since we have only one prefab per button click
    public void SelectPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;

    }

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0) && selectedPrefab != null)
        {
            Turret t = selectedPrefab.GetComponent<Turret>();
            if(mm.money - t.cost >= 0) //checks if player has enough money for turret
            {
                // Get the position of the mouse click in world space
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Convert the click position to a cell position on the Tilemap
                Vector3Int cellPosition = tilemap.WorldToCell(clickPosition);

                // Place the selected prefab at the cell position on the Tilemap
                GameObject pI = Instantiate(selectedPrefab, tilemap.GetCellCenterWorld(cellPosition), Quaternion.identity, tilemap.transform);

                pI.transform.localScale = new Vector3(prefabSize.x * tilemap.cellSize.x, prefabSize.y * tilemap.cellSize.y, prefabSize.z * tilemap.cellSize.z);
                pI.transform.parent = tilemap.transform;

                mm.money = mm.money - t.cost;
            }
            else{
                //do like prompt saying not sufficiant funds
            }
           
            //sets to null for next button click
            selectedPrefab = null;
        
        }
    }
}
