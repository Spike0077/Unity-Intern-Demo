using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // 碰撞开始时自动调用
    void OnCollisionEnter(Collision collision)
    {
        // 在控制台输出碰撞到的物体的名字
        Debug.Log("✅ 碰撞开始，碰到了：" + collision.gameObject.name);

        // 如果碰撞到的是地面（名字叫Plane）
        if (collision.gameObject.name == "Plane")
        {
            // 获取当前物体的Mesh Renderer组件，把材质颜色改成红色
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // 碰撞持续时自动调用（每帧一次）
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("🔄 正在碰撞中...");
    }

    // 碰撞结束时自动调用
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("❌ 碰撞结束");
        // 把材质颜色恢复成白色
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}