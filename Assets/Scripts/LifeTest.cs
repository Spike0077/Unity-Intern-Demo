using UnityEngine;

public class LifeTest : MonoBehaviour
{
    // 声明一个计数器变量
    private int count;

    void Start()
    {
        // 只在游戏开始时把计数器设为0，执行1次
        Debug.Log("Start：初始化计数器 count = " + count);
    }

    void Update()
    {
        count = 0; // 错误写法：每帧都重置为0
        count = count + 1;
        Debug.Log("Update：计数器当前值 = " + count);
    }
}