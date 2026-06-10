using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 子弹碰到任何物体都会销毁自己
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}