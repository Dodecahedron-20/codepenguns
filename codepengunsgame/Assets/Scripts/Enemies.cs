using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private bool seenPlayer;
    [SerializeField]
    private bool shotBullet = false;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float currentCDTimer;
    [SerializeField]
    private float setCDTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shotBullet == true)
        {
            currentCDTimer = Mathf.Clamp(currentCDTimer -= Time.deltaTime, 0f, setCDTimer);
        }

        if(currentCDTimer <= 0f)
        {
            shotBullet = false;
        }

        if (seenPlayer == true)
        {         
            Shoot();
        }
    }

    private void Shoot()
    {
        if(currentCDTimer <= 0f && shotBullet == false)
        {
            Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
            currentCDTimer = setCDTimer;
            shotBullet = true;
        }
    }
}
