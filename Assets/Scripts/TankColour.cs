using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColour : MonoBehaviour
{

    public Transform meshRedererManager;
    public Material tankColour;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in meshRedererManager)
        {
            var mesh = child.GetComponent<MeshRenderer>();

            Material[] mats = mesh.materials;
            mats[0] = tankColour;
            mesh.materials = mats;
        }
    }

    
}
