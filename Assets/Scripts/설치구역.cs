using UnityEngine;
using System.Collections;

public class 설치구역 : MonoBehaviour
{
    [Header("설치 가능 여부")]
    public bool 설치가능 = true;

    [Header("설치된 유닛 정보")]
    public 아군유닛 설치된유닛; // 설치된 유닛의 ScriptableObject 정보
    public GameObject 설치된오브젝트; // 인스턴스된 유닛 프리팹




    // 유닛 설치 함수
   public void 유닛설치(아군유닛 유닛데이터, GameObject 유닛프리팹)
{
    if (!설치가능) return;

    설치된유닛 = 유닛데이터;
    설치된오브젝트 = Instantiate(유닛프리팹, transform.position, Quaternion.identity);
    설치가능 = false;

    // 스프라이트 설정
    SpriteRenderer sr = 설치된오브젝트.GetComponent<SpriteRenderer>();
    if (sr != null)
        sr.sprite = 유닛데이터.유닛스프라이트;

    // 유닛 정보 초기화
    설치유닛 unitScript = 설치된오브젝트.GetComponent<설치유닛>();
    if (unitScript != null)
        unitScript.초기화(유닛데이터);
}


    // 설치된 유닛만 제거
    public void 제거()
    {
        if (설치된오브젝트 != null)
        {
            Destroy(설치된오브젝트);
            설치된오브젝트 = null;
            설치된유닛 = null;
            설치가능 = true;

            Debug.Log("유닛이 제거되었습니다. 설치 가능 상태로 복귀.");
        }
    }

    // 설치구역 자체를 파괴
    public void 파괴()
    {
        제거(); // 설치된 유닛 먼저 제거
        Destroy(gameObject); // 설치구역 자체 삭제
        Debug.Log("설치구역이 파괴되었습니다.");
    }

    public void hp감소()
{
    if (설치된오브젝트 != null)
    {
        설치유닛 unitScript = 설치된오브젝트.GetComponent<설치유닛>();
        if (unitScript != null)
        {
            unitScript.데미지입기(20);
        }
    }
}

}

   