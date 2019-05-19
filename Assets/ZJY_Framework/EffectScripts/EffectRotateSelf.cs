using UnityEngine;
using System.Collections;

public class EffectRotateSelf : MonoBehaviour
{
    public float rotationSpeedX = 90;
    public float rotationSpeedY = 0;
    public float rotationSpeedZ = 0;
    private Vector3 rotationVector = new Vector3(0, 90, 0);
    private Transform _transform;
   
    void Start()
    {
        rotationVector = new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
        _transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
            _transform.Rotate(rotationVector * Time.deltaTime);
    }
}
