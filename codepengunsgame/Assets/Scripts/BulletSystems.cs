using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSystems : MonoBehaviour
{

    public static BulletSystems _instance;

    public static BulletSystems Instance { get { return _instance; } }


    public int currentBullets;

    public bool shoot = false;


    //HUD components
    [SerializeField]
    private Text bulletCountText;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(shoot == true)
        {
            shoot = false;
            SetBulletCount(currentBullets);
        }
    }


    public void SetBulletCount(int b)
    {
        currentBullets = b;
        bulletCountText.text = "" + b;
    }



    private void OnApplicationQuit()
    {
        _instance = null;
    }

}
