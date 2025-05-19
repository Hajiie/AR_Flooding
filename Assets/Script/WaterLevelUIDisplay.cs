using UnityEngine;
using TMPro;

public class WaterLevelUIDisplay : MonoBehaviour
{
    [Header("References")]
    public Transform waterBox;         // Water 큐브 Transform
    public TextMeshProUGUI levelText;  // 우측 중단 텍스트
    // OVROverlay text
    //public OVROverlay overlaytext;
    //public Transform CameraY;         // 카메라 Y 
    
    public GameObject waterFollowHeadObj; // WaterFollowHead 스크립트가 붙은 오브젝트
    
    [Header("Display")]
    public string unit = "m";          // 단위 문자열
    public int decimals = 2;           // 소수점 자리

    void Update()
    {
        if (!waterBox || !levelText) return;

        float height = 0.5f + waterBox.position.y + waterBox.localScale.y / 2f + waterFollowHeadObj.GetComponent<WaterFollowHead>().GetDeltaY();   // 월드 Y (m)
        levelText.text = "Water Height : " + height.ToString($"F{decimals}") + " " + unit;
        //+ "\n" + (waterFollowHeadObj.GetComponent<WaterFollowHead>().GetDeltaY()).ToString($"F{decimals}"); // 카메라 Y - 수면 높이
    }
}