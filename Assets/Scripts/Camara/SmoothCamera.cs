using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform target;

    private float radius = 2f;
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    

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

    public void Update()
    {
        Vector3 mousePosition = MousePosition.GetMouseWorldPosition();

        Vector3 newPosition = new Vector3(
          (mousePosition.x - target.position.x) / 2f + target.position.x,
          (mousePosition.y - target.position.y) / 2f + target.position.y,
          transform.position.z
        );

        float dist = Vector2.Distance(
          new Vector2(newPosition.x, newPosition.y),
          new Vector2(target.position.x, target.position.y)
        );

        if (dist > radius)
        {
            Vector3 mouseOffset = mousePosition - target.position;
            var norm = mouseOffset.normalized;
            newPosition = new Vector3(
              norm.x * radius + target.position.x,
              norm.y * radius + target.position.y,
              transform.position.z
            );
        }
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
}

public class MousePosition
{
    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
