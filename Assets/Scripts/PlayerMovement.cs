using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalIpunt = Input.GetAxis("Horizontal");
        float veticalInput = Input.GetAxis("Vertical");

        //Se mover na diagonal a magnitude do vetor ficar maior que 1
        //Por isso move-se mais rápido diagonal
        Vector3 movementDirection = new Vector3(horizontalIpunt, 0, veticalInput);
        float magnitude = movementDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        //Normalizar o vetor mantem a magnitute em 1
        movementDirection.Normalize();

        //transform.Translate(movementDirection * magnitude * Time.deltaTime * speed, Space.World);
        characterController.SimpleMove(movementDirection);

        //Caso o movimento for diferente de zero
        //Rotacionar o objeto de acordo com a direção do movimento
        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
