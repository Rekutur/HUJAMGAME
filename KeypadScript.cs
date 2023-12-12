using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadScript : MonoBehaviour
{
    public PlayerManager player;
    public float keypadLVL;
    [SerializeField] GameObject Wall;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite door_open;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (keypadLVL)
            {
                case (1):
                    if (player.hasKey1)
                    {
                        Wall.SetActive(false);
                        spriteRenderer.sprite = door_open;
                    }
                    break;
                case (2):
                    if (player.hasKey2)
                    {
                        Wall.SetActive(false);
                        spriteRenderer.sprite = door_open;
                    }
                    break;
                case (3):
                    if (player.hasKey3)
                    {
                        Wall.SetActive(false);
                        spriteRenderer.sprite = door_open;
                    }
                    break;
            }

        }

    }
}
