using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestScript : MonoBehaviour
{
    public GameObject[] LootTable;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite box_open;
    [SerializeField] Collider2D box_collider;
    bool isOpened = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isOpened)
        {
            StartCoroutine(LootDropCalculator());
        }
    }

    public IEnumerator LootDropCalculator()
    {
        int lootRoll = Random.Range(0, 15);
        if (lootRoll <= 1) Instantiate(LootTable[0], this.transform.position, this.transform.rotation);
        if (lootRoll > 2 && lootRoll < 7) Instantiate(LootTable[1], this.transform.position, this.transform.rotation);
        if (lootRoll > 7 && lootRoll < 13) Instantiate(LootTable[2], this.transform.position, this.transform.rotation);
        if (lootRoll > 13) Instantiate(LootTable[3], this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = box_open;
        box_collider.enabled = false;
        isOpened = true;
    }
}
