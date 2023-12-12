using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject playScreen;
    [SerializeField] GameObject namlu;
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shoot;
    public int bulletCount = 0;
    public int bulletCurrent;
    public int bulletMax = 20;
    public string gunType;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && playScreen.gameObject.activeInHierarchy && bulletCount >= 1)
        {
            Shoot();
        }
        else if (bulletCount <= 0)
        {
            Reload();
        }
    }
    private void Awake()
    {
        Debug.Log(gunType);
        switch (gunType)
        {
            case "pistol":
                DataManager.Instance.ammoPistol = bulletCurrent;
                break;
            case "shotgun":
                DataManager.Instance.ammoShotty = bulletCurrent;
                break;
            case "laser":
                DataManager.Instance.ammoLaser = bulletCurrent;
                break;
            case "shuriken":
                DataManager.Instance.ammoShuriken = bulletCurrent;
                break;
            case "minigun":
                DataManager.Instance.ammoMinigun = bulletCurrent;
                break;
            case "sword":
                break;
        }
    }
    void Shoot()
    {
        shoot.Play();
        switch (gunType)
        {
            case "pistol":
                DataManager.Instance.ammoPistol--;
                bulletCurrent = DataManager.Instance.ammoPistol;
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                bulletCount = bulletCurrent;
                break;
            case "shotgun":
                Debug.Log("Shotgunfired");
                DataManager.Instance.ammoShotty--;
                bulletCurrent = DataManager.Instance.ammoShotty;
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                bulletCount = bulletCurrent;
                break;
            case "laser":
                DataManager.Instance.ammoLaser--;
                bulletCurrent = DataManager.Instance.ammoLaser;
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                bulletCount = bulletCurrent;
                break;
            case "shuriken":
                DataManager.Instance.ammoShuriken--;
                bulletCurrent = DataManager.Instance.ammoShuriken;
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                bulletCount = bulletCurrent;
                break;
            case "minigun":
                DataManager.Instance.ammoMinigun--;
                bulletCurrent = DataManager.Instance.ammoMinigun;
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                bulletCount = bulletCurrent;
                break;
            case "sword":
                Instantiate(bullet, namlu.transform.position, namlu.transform.rotation);
                break;
        }
    }
    void Reload()
    {
        if(bulletMax >6)
        {
            bulletMax -= 6;
            bulletCurrent += 6;
            bulletCount = bulletCurrent;
        }
        else
        {
            bulletCurrent += bulletMax;
            bulletMax = 0;
            bulletCount = bulletCurrent;
        }

    }
}
