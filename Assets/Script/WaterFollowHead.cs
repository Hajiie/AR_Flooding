using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollowHead : MonoBehaviour
{
    //head의 Y 좌표가 바뀔 때마다 waterBox의 Y 좌표를 갱신
    [Header("References")]
    public Transform waterBox;         // Water 큐브 Transform
    public float offset = 0f;          // 수면 높이 오프셋
    public Transform head;             // CenterEyeAnchor Transform
    public float minDelta = 0.01f;      // 감지 임계값
    
    float prevHeadY;

    private float deltaY = 0f;           // head의 Y 좌표 변화량
    
    // Start is called before the first frame update
    void Start()
    {
        if (head)
        {
            prevHeadY = head.position.y;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!waterBox || !head) return;

        float currentY = head.position.y;
        deltaY = currentY - prevHeadY; // head의 Y 좌표 변화량
        if (Mathf.Abs(deltaY) >= minDelta)
        {
            waterBox.position -= new Vector3(
                0f,
                deltaY + offset,
                0f)*10f; // 월드 Y 위치로 수면을 절대 관리

            prevHeadY = currentY;
        }
    }
    
    public float GetDeltaY()
    {
        return deltaY;
    }
}
