using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "아군유닛", menuName = "Scriptable Objects/아군유닛")]
public class 아군유닛 : ScriptableObject
{
    [Header("유닛 능력치")]
    public int hp;
    public int 공격력;

    [Header("유닛 외형")]
    public Sprite 유닛스프라이트;
}
