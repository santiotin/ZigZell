using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogo : MonoBehaviour
{
    Vector3 rotationZ = new Vector3(0.0f, 0.0f, 100.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( rotationZ * Time.deltaTime * -1.0f , Space.Self);
    }
}
