using UnityEngine;

public class VariablePractice : MonoBehaviour
{
    // 🔴 公共变量：仅用于需要外部访问的参数
    public float jumpForce = 300f;

    // 🟢 最佳实践：私有变量+序列化，编辑器可见可改，外部无法访问
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Color hitColor = Color.red;

    // ⚫ 纯私有变量：仅脚本内部使用，编辑器不可见
    private MeshRenderer _mr;
    private Rigidbody _rb;
    private bool _canJump = true; // 新增：跳跃状态控制

    void Start()
    {
        // 只在Start里获取一次组件
        _mr = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. 移动逻辑（用本脚本自己的moveSpeed参数）
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _rb.velocity = new Vector3(
            horizontalInput * moveSpeed,
            _rb.velocity.y,
            verticalInput * moveSpeed
        );

        // 2. 跳跃逻辑（用本脚本自己的jumpForce参数）
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _rb.AddForce(Vector3.up * jumpForce);
            _canJump = false;
        }

        // 3. 变色逻辑（用本脚本自己的hitColor参数）
        if (Input.GetKeyDown(KeyCode.J))
        {
            _mr.material.color = hitColor; // 改Inspector的hitColor这里会变
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _mr.material.color = Color.white;
        }

        // 4. 重置玩家
        if (Input.GetKeyDown(KeyCode.L))
        {
            ResetPlayer();
        }

        // 5. 下蹲功能
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    // 碰撞地面恢复跳跃能力
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            _canJump = true;
            // 可选：落地自动变色
             _mr.material.color = hitColor;
            // 新增：延迟1秒后自动调用ResetPlayer函数
            Invoke(nameof(ResetPlayer), 1f);
        }
    }

    // 自定义函数：重置玩家状态
    private void ResetPlayer()
    {
        _mr.material.color = Color.white;
        transform.position = new Vector3(0, 2, 0);
    }
}