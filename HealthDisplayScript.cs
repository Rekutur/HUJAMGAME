using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Image spriteRenderer;
    [SerializeField] Sprite sprite1, sprite2, sprite3, sprite4;
    void Start()
    {
        //playerManager = GetComponent<PlayerManager>();
    }
    void LateUpdate()
    {
        if (playerManager.health >= 50)
        {
            spriteRenderer.sprite = sprite1;
        }
        else if (playerManager.health <= 50 && playerManager.health > 30)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (playerManager.health <= 30 && playerManager.health > 15)
        {
            spriteRenderer.sprite = sprite3;
        }
        else if (playerManager.health <= 15 && playerManager.health > 1)
        {
            spriteRenderer.sprite = sprite4;
        }
    }

}
