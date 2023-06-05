using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField] private RandomizerData data;
    // Start is called before the first frame update
    private void Awake()
    {
        data.StartRun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
