using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButtonScript : MonoBehaviour
{
    public Slider STRslider, ENDslider, LUKslider, SPDslider;
    public void STRUP()
    {
        if(DataManager.Instance.credits >= 100 && DataManager.Instance.STR_stat <= 5)
        {
            DataManager.Instance.credits -= 100;
            DataManager.Instance.STR_stat++;
            STRslider.maxValue = 5;
            STRslider.value = DataManager.Instance.STR_stat;
        }
    }
    public void ENDUP()
    {
        if (DataManager.Instance.credits >= 100 && DataManager.Instance.END_stat <= 5 )
        {
            DataManager.Instance.credits -= 100;
            DataManager.Instance.END_stat++;
            ENDslider.maxValue = 5;
            ENDslider.value = DataManager.Instance.END_stat;
        }
    }
    public void LUKUP()
    {
        if (DataManager.Instance.credits >= 100 && DataManager.Instance.LUK_stat <= 5)
        {
            DataManager.Instance.credits -= 100;
            DataManager.Instance.LUK_stat++;
            LUKslider.maxValue = 5;
            LUKslider.value = DataManager.Instance.LUK_stat;
        }
    }
    public void SPDUP()
    {
        if (DataManager.Instance.credits >= 100 && DataManager.Instance.SPD_stat <= 5)
        {
            DataManager.Instance.credits -= 100;
            DataManager.Instance.SPD_stat++;
            SPDslider.maxValue = 5;
            SPDslider.value = DataManager.Instance.SPD_stat;
        }
    }

}
