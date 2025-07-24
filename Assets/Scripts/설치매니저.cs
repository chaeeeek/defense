using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class 설치매니저 : MonoBehaviour
{
    [Header("설치할 유닛 데이터 및 프리팹")]
    public 아군유닛 유닛데이터;          // ScriptableObject 데이터
    public GameObject 유닛프리팹;         // 프리팹 (스프라이트 출력 포함)

    [Header("레이어 마스크")]
    public LayerMask 설치구역레이어;      // 설치 가능한 영역만 클릭되도록

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("클릭");

            Vector2 마우스위치 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(마우스위치, Vector2.zero, 0f, 설치구역레이어);
            if (hit.collider != null)
            {
                설치구역 zone = hit.collider.GetComponent<설치구역>();
                if (zone != null && zone.설치가능)
                {
                    zone.유닛설치(유닛데이터, 유닛프리팹);
                }
                else
                {
                    Debug.Log("설치불가 또는 설치구역이 아님");
                }
            }
            else
            {
                Debug.Log("설치구역을 클릭하지 않음");
            }
        }
    }
}
