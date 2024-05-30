using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class samsung_bt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Button 컴포넌트 가져오기
        Button button = GetComponent<Button>();

        // 버튼이 눌렸을 때 호출할 함수 지정
        button.onClick.AddListener(ActivatesamsungScript);
    }

    // 버튼을 눌렀을 때 호출되는 함수
    void ActivatesamsungScript()
    {
        // 메인 카메라에서 ecopro 스크립트 가져오기
        samsung samsungScript = Camera.main.GetComponent<samsung>();

        // ecopro 스크립트가 존재하고 비활성화 상태인 경우에만 활성화
        if (samsungScript != null && !samsungScript.enabled)
        {
            samsungScript.enabled = true;
        }
    }
}
