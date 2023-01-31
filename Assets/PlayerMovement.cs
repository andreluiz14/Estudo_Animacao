using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalIpunt = Input.GetAxis("Horizontal");
        float veticalInput = Input.GetAxis("Vertical");

        //Se mover na diagonal a magnitude do vetor ficar maior que 1
        //Por isso move-se mais rápido diagonal
        Vector3 movementDirection = new Vector3(horizontalIpunt, 0, veticalInput);

        //Normalizar o vetor mantem a magnitute em 1
        movementDirection.Normalize();

        transform.Translate(movementDirection * Time.deltaTime * speed);
    }
}
