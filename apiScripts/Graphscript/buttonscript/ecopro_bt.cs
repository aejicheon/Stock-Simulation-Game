using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ecopro_bt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Button 컴포넌트 가져오기
        Button button = GetComponent<Button>();

        // 버튼이 눌렸을 때 호출할 함수 지정
        button.onClick.AddListener(ActivateEcoproScript);
    }

    // 버튼을 눌렀을 때 호출되는 함수
    void ActivateEcoproScript()
    {
        // 메인 카메라에서 ecopro 스크립트 가져오기
        ecopro ecoproScript = Camera.main.GetComponent<ecopro>();

        // ecopro 스크립트가 존재하고 비활성화 상태인 경우에만 활성화
        if (ecoproScript != null && !ecoproScript.enabled)
        {
            ecoproScript.enabled = true;
        }
       
    }
}
