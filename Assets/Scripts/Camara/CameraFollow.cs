using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public float xOffset =1f;
    public Transform target;

    private void OnEnable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void OnDisable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void SetPlayerRef(GameObject player)
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
            transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
        
    }
}