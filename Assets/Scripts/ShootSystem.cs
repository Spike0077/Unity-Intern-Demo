using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    // 子弹预制体：把Project里的Bullet拖到这个变量上
    [SerializeField] private GameObject bulletPrefab;

    // 发射点：在玩家前方生成子弹的位置
    [SerializeField] private Transform firePoint;

    // 子弹飞行速度
    [SerializeField] private float bulletSpeed = 20f;

    // 子弹自动销毁时间：防止内存泄漏
    [SerializeField] private float bulletLifeTime = 3f;

    void Update()
    {
        // 按下空格键发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // 发射子弹函数：封装所有发射逻辑
    private void Shoot()
    {
        // 1. 实例化子弹：在发射点位置，和发射点同方向
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. 获取子弹的刚体组件，给它一个向前的速度
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;

        // 3. 3秒后自动销毁子弹
        Destroy(bullet, bulletLifeTime);
    }
}