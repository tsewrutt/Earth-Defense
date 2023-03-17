using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = 1000;
    public Text moneyTxt;
    void Start()
    {
        UpdateMoneyText();
    }

    // Update is called once per frame
    void Update()
    {
        /*  if(tp.selectedPrefab != null)
          {
              if(flag == true)
              {
                  Turret t = tp.selectedPrefab.GetComponent<Turret>();
                  money = money - t.cost;
                  UpdateMoneyText();
                  flag = false;
              }

          }
          else
          {
             // flag = true;
          }*/
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyTxt.text = ""+ money;
    }



}
