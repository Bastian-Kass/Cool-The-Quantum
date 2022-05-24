using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorCharacteristics : MonoBehaviour
{

    
    public GameObject indicator;

    private float gridSize;

    // Start is called before the first frame update
    void Start()
    {
        gridSize = transform.localScale.x;
        float gridSize_half = gridSize / 2;
        //Ensuring each child's position
        GameObject x;

        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( gridSize_half,  gridSize_half,  gridSize_half);
        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( gridSize_half,  gridSize_half, -gridSize_half);

        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( gridSize_half,  -gridSize_half, gridSize_half);
        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( gridSize_half,  -gridSize_half, -gridSize_half);

        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( -gridSize_half,  gridSize_half, gridSize_half);
        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( -gridSize_half,  gridSize_half, -gridSize_half);

        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( -gridSize_half,  -gridSize_half, gridSize_half);
        x = Instantiate(indicator, transform, false);
        x.transform.position = x.transform.position + new Vector3 ( -gridSize_half,  -gridSize_half, -gridSize_half);
        
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube( Vector3.zero, new Vector3(gridSize, gridSize, gridSize));
    }


}
