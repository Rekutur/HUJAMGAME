using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomizationScript : MonoBehaviour
{
    public int skinNr;
    public Skins1[] skins;
    public string tip;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (skinNr > skins.Length-1) skinNr = 0;
        else if (skinNr < 0) skinNr = skins.Length - 1;
    }
    void LateUpdate()
    {
        SkinPick();
    }

    public void SkinNext ()
    {
        skinNr++;
        if (skinNr > skins.Length-1) skinNr = 0;
        else if (skinNr < 0) skinNr = skins.Length - 1;
    }
    public void SkinPrev ()
    {
        skinNr--;
        if (skinNr > skins.Length-1) skinNr = 0;
        else if (skinNr < 0) skinNr = skins.Length - 1;
    }
    void SkinPick()
    {
        string spriteName = spriteRenderer.sprite.name;
        spriteName = spriteName.Replace(tip+"_", "");
        int spriteNr = (int.Parse(spriteName));
        spriteRenderer.sprite = skins[skinNr].sprites[0];//sprites[spriteNr];
    }
    [System.Serializable]
    public struct Skins1
    {
        public Sprite[] sprites;
    }
}
