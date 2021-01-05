using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float playerMoveSpeed = 10f;
    [SerializeField] float padding = 0.1f; 

    float xMin, xMax, yMin, yMax; 

    // Start is called before the first frame update
    void Start()
    {
        GameCamera();
    }

    private void GameCamera()
    {
        Camera gamecamera = Camera.main;

        xMin = gamecamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gamecamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gamecamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gamecamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding; 
    }
    // Update is called once per frame
    void Update()
    {
        playerMove();   
    }

    private void playerMove()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, yMin); 
    }
}
