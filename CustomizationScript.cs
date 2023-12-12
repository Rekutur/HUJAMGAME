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
        if (skinNr > skins.Length) skinNr = 0;
        else if (skinNr < 0) skinNr = skins.Length - 1;
    }
    void LateUpdate()
    {
        SkinPick();
    }

    public void SkinNext ()
    {
        skinNr++;
    }
    public void SkinPrev ()
    {
        skinNr--;
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
    /*
        
        skinSR = skin.GetComponent<SpriteRenderer>();
        hairSR = hair.GetComponent<SpriteRenderer>();
        faceSR = face.GetComponent<SpriteRenderer>();
        shirtSR = shirt.GetComponent<SpriteRenderer>();
        pantsSR = pants.GetComponent<SpriteRenderer>();
        shoesSR = shoes.GetComponent<SpriteRenderer>();
    private SpriteRenderer skinSR, hairSR, eyesSR, faceSR, shirtSR, pantsSR, shoesSR;
    public enum pantsprites
    {
        pants1,
        pants2,
        pants3,
        pants4
    }
    public enum shirtsprites
    {
        shirts1,
        shirts2,
        shirts3,
        shirts4,
        shirts5,
        shirts6,
        shirts7,
        shirts8,
        shirts9,
        shirts10
    }
    public enum eyesprites
    {
        eyes1,
        eyes2,
        eyes3,
        eyes4,
        eyes5,
        eyes6,
        eyes7,
        eyes8,
        eyes9,
        eyes10
    }
    public enum hairsprites
    {
        hair1,
        hair2,
        hair3,
        hair4,
        hair5,
        hair6,
        hair7,
        hair8,
        hair9,
        hair10,
        hair11,
        hair12,
        hair13,
        hair14,
        hair15,
        hair16,
        hair17,
        hair18,
        hair19,
        hair20,
        hair21,
        hair22,
        hair23,
        hair24,
        hair25,
        hair26,
        hair27,
        hair28,
        hair29,
        hair30,
        hair31,
        hair32,
        hair33,
        hair34,
        hair35,
        hair36,
        hair37,
        hair38,
        hair39,
        hair40,
        hair41,
        hair42,
        hair43,
        hair44,
        hair45,
        hair46,
        hair47,
        hair48,
    }
    public enum facesprites
    {
        face1,
        face2,
        face3,
        face4,
        face5,
        face6,
        face7,
        face8,
        face9,
        face10
    }
    public enum shoesprites
    {
        shoes1,
        shoes2,
        shoes3,
        shoes4
    }
    [SerializeField] GameObject skin, hair, eyes, face, shirt, pants, shoes;*/
}
