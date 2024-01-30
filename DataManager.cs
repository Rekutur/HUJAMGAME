using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using System.Runtime.InteropServices.WindowsRuntime;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [SerializeField] CustomizationScript skin, hair, eyes, face, shirt, pants, shoes;
    private int playerSkin;
    private int playerHair;
    private int playerEyes;
    private int playerFace;
    private int playerShirt;
    private int playerPants;
    private int playerShoes;
    public int skinNum, hairNum, eyeNum, faceNum, shirtNum, pantNum, shoeNum;
    EasyFileSave myFile;
    public int credits;
    public int ammoPistol, ammoShotty, ammoMinigun, ammoShuriken, ammoLaser;
    public int activeEnemy;
    public int STR_stat = 1, SPD_stat = 1, END_stat = 1, LUK_stat = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        playerSkin = skin.skinNr;
        playerHair = hair.skinNr;
        playerEyes = eyes.skinNr;
        playerFace = face.skinNr;
        playerShirt = shirt.skinNr;
        playerPants = pants.skinNr;
        playerShoes = shoes.skinNr;
        skinNum = playerSkin;
        hairNum = playerHair;
        eyeNum = playerEyes;
        pantNum = playerPants;
        shirtNum = playerShirt;
        shoeNum = playerShoes;
        faceNum = playerFace;


        myFile.Add("playerSkin", skinNum);
        myFile.Add("playerHair", hairNum);
        myFile.Add("playerEyes", eyeNum);
        myFile.Add("playerPants", pantNum);
        myFile.Add("playerShirt", shirtNum);
        myFile.Add("playerShoes", shoeNum);
        myFile.Add("playerFace", faceNum);

        myFile.Save();
    }
    private void OnLevelWasLoaded(int level)
    {
        skin = GameObject.Find("Skin").GetComponent<CustomizationScript>();
        hair = GameObject.Find("Hair").GetComponent<CustomizationScript>();
        eyes = GameObject.Find("Eyes").GetComponent<CustomizationScript>();
        face = GameObject.Find("Face").GetComponent<CustomizationScript>();
        shirt = GameObject.Find("Shirt").GetComponent<CustomizationScript>();
        pants = GameObject.Find("Pants").GetComponent<CustomizationScript>();
        shoes = GameObject.Find("Shoes").GetComponent<CustomizationScript>();
        skin.skinNr = playerSkin;
        hair.skinNr = playerHair;
        eyes.skinNr = playerEyes;
        face.skinNr = playerFace;
        pants.skinNr = playerPants;
        shirt.skinNr = playerShirt;
        shoes.skinNr = playerShoes;
    }
    public void LoadData()
    {
        if (myFile.Load())
        {
            playerSkin = myFile.GetInt("playerSkin");
            playerHair = myFile.GetInt("playerHair");
            playerEyes = myFile.GetInt("playerEyes");
            playerPants = myFile.GetInt("playerPants");
            playerShirt = myFile.GetInt("playerShirt");
            playerShoes = myFile.GetInt("playerShoes");
            playerFace = myFile.GetInt("playerFace");

            Debug.Log("I LOADED");
        }
    }

    public void Win()
    {
    }
    public void Lose()
    {
        Debug.Log("You Lost.");
        myFile.Dispose();
    }
}
