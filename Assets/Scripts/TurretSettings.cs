using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret Shop Setting")]
public class TurretSettings : ScriptableObject
{
    // Start is called before the first frame update
    public GameObject TurretPrefab;
    public int TuretCost;
    public Sprite TurretShopSprite;
}
