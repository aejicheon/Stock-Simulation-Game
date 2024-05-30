using UnityEngine;
using UnityEngine.UI;

public class DotControl : MonoBehaviour
{
    // 비활성화 기준 위치
    public float deactivationThreshold = 1f;
    private Image imageComponent;

    void Start()
    {
        // Image 컴포넌트 가져오기
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentXPosition = transform.position.x;

        if (currentXPosition < deactivationThreshold && imageComponent.enabled)
        {
            // Image 비활성화
            imageComponent.enabled = false;
        }
        else if (currentXPosition >= deactivationThreshold && !imageComponent.enabled)
        {
            // Image 활성화
            imageComponent.enabled = true;
            //Debug.Log("Image가 활성화됨");
        }

    }
}
