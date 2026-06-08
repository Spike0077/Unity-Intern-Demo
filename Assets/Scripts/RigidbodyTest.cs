using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    // 声明一个变量，用来存储当前物体的刚体组件
    private Rigidbody rb;

    // 游戏开始第一帧调用
    void Start()
    {
        // 自动获取当前物体上的Rigidbody组件
        rb = GetComponent<Rigidbody>();

        // 给物体一个向上的力，力的大小是500
        rb.AddForce(Vector3.up * 1000);

        // 给物体一个绕X轴旋转的力👋
        rb.AddTorque(Vector3.right * 100);
    }
}