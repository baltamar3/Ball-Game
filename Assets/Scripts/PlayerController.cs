using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movVertical, movHorizontal;
    public float velocidad = 1.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movVertical = Input.GetAxis("Vertical");
        movHorizontal = Input.GetAxis("Horizontal");
        print(movHorizontal);

        Vector3 movimiento = new Vector3(movHorizontal, 0.0f ,movVertical); 

        rb.AddForce(movimiento*velocidad);
    }
}
