using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UnderwaterController : MonoBehaviour
{
    public Transform waterSurface;        // WaterBox 상단 Y
    public Volume underwaterVolume;       // Post-processing Volume
    public float fadeSpeed = 3f;          // 가중치 보간

    void Update()
    {
        float camY = Camera.main.transform.position.y;
        bool inWater = camY < waterSurface.position.y;   // 수면 아래?

        // 볼륨 weight(0~1) LERP
        float target = inWater ? 1f : 0f;
        underwaterVolume.weight = Mathf.MoveTowards(
            underwaterVolume.weight, target, Time.deltaTime * fadeSpeed);
    }
}