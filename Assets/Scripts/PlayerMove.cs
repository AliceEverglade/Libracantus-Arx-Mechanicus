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
        float X = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Translate(X * speed, 0, 0);

        float Y = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(Y * speed, 0, 0);
    }
}
