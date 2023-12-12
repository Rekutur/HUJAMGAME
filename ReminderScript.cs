using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderScript : MonoBehaviour
{
    public void Awake()
    {
        DataManager.Instance.LoadData();
    }
}
