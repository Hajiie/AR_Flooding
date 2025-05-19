using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WaterController : MonoBehaviour
{
    [Header("References")]
    public Transform waterBox;
    public float moveSpeed = 5f;
    public float minY = -50f;
    public float maxY = 50f;
    
    private float currentY = -50f; // 월드 Y 위치로 수면을 절대 관리
    
    // Start is called before the first frame update
    void Start()
    {
        if (waterBox)
        {
            waterBox.SetParent(null, true);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 joystick;
        bool success = UnityEngine.XR.InputDevices
            .GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand)
            .TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out joystick);

        if (success && Mathf.Abs(joystick.y) > 0.01f)
        {
            float deltaY = joystick.y * moveSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY + deltaY, minY, maxY);

            Vector3 pos = waterBox.position;
            pos.y = currentY;
            waterBox.position = pos;
        }
    }
}
