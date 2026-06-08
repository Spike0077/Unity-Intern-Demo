using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // 物体进入触发区域时自动调用
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🎉 " + other.gameObject.name + " 进入了触发区域");
    }

    // 物体在触发区域内时自动调用
    void OnTriggerStay(Collider other)
    {
        Debug.Log("⏳ " + other.gameObject.name + " 正在触发区域内");
    }

    // 物体离开触发区域时自动调用
    void OnTriggerExit(Collider other)
    {
        Debug.Log("👋 " + other.gameObject.name + " 离开了触发区域");
    }
}