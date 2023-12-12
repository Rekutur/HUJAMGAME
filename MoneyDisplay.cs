using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    // Update is called once per frame
    public void UpdateMoney()
    {
        moneyText.text = DataManager.Instance.credits.ToString();
    }
    public void Update()
    {
        moneyText.text = DataManager.Instance.credits.ToString();
    }
}
