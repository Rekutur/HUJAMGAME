using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    public void UpdateMoney()
    {
        moneyText.text = DataManager.Instance.credits.ToString();
    }
}
