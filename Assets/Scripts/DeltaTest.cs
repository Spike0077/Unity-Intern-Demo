using UnityEngine;

public class DeltaTest : MonoBehaviour
{
    void Update()
    {
        // 写法1：不带Time.deltaTime
        // 问题：帧率越快，移动越快，不同电脑速度不一样
        // transform.Translate(0, 0, 0.1f);

        // 写法2：乘以Time.deltaTime
        // 优点：所有设备上移动速度统一，每秒移动2米
         transform.Translate(0, 0, 2 * Time.deltaTime);
    }
}