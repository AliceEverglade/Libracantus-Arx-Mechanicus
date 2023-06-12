using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;

    [SerializeField] private float speed;

    public bool spinning = false;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (spinning)
        {
            Spin();
        }
        else
        {
            transform.LookAt(player.transform);
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Spin()
    {
        if (transform.rotation.z < 100)
        {
            transform.Rotate(0, 0, 1);
            GameObject bulletObject;
            bulletObject = Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
            bulletObject.transform.LookAt(player.transform);
            bulletObject.transform.rotation = new Quaternion(0, 0, bulletObject.transform.rotation.z, bulletObject.transform.rotation.w);
        }
        else
        {
            spinning = false;
        }
    }
}
