using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform playerTransform;

    private float radius = 2f;
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public void Update()
    {
        Vector3 mousePosition = MousePosition.GetMouseWorldPosition();

        Vector3 newPosition = new Vector3(
          (mousePosition.x - playerTransform.position.x) / 2f + playerTransform.position.x,
          (mousePosition.y - playerTransform.position.y) / 2f + playerTransform.position.y,
          transform.position.z
        );

        float dist = Vector2.Distance(
          new Vector2(newPosition.x, newPosition.y),
          new Vector2(playerTransform.position.x, playerTransform.position.y)
        );

        if (dist > radius)
        {
            Vector3 mouseOffset = mousePosition - playerTransform.position;
            var norm = mouseOffset.normalized;
            newPosition = new Vector3(
              norm.x * radius + playerTransform.position.x,
              norm.y * radius + playerTransform.position.y,
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
