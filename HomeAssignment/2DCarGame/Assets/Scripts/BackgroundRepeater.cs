using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    [SerializeField] float backgroundRepeaterSpeed = 0.15f;

    //the material from the texture
    Material myMaterial;

    //movement offset
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        //get the material of Background from Renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis at the given speed
        offSet = new Vector2(0f, backgroundRepeaterSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //move the texture of the material by offSet every frame
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
