using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Vertical") * Time.fixedDeltaTime;

        transform.Translate(0, X * speed, 0);

        float Y = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;

        transform.Translate((Y * speed), 0, 0);
        Debug.Log(X);
    }
}
