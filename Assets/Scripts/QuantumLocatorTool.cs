
using UnityEngine;

public class QuantumLocatorTool : MonoBehaviour
{

    public GameObject LocatorPointer;
    public GameObject LocatorIndicator;
    private float size_x;
    private float size_y;
    private float size_z;

    private Vector3 indicatorPosition;
    // Start is called before the first frame update
    void Start()
    {
        indicatorPosition = new Vector3();

        size_x = LocatorIndicator.transform.localScale.x;  
        size_y = LocatorIndicator.transform.localScale.y; 
        size_z = LocatorIndicator.transform.localScale.z; 

    }

    // Update is called once per frame
    void Update()
    {
        indicatorPosition.x = Mathf.Round(LocatorPointer.transform.position.x / size_x) * size_x - size_x/2;
        indicatorPosition.y = Mathf.Round(LocatorPointer.transform.position.y / size_y) * size_y - size_y/2;
        indicatorPosition.z = Mathf.Round(LocatorPointer.transform.position.z / size_z) * size_z - size_z/2;

        LocatorIndicator.transform.position = indicatorPosition;
        LocatorIndicator.transform.rotation = Quaternion.identity;

    }
}
