using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移动速度，public【公共变量】可以在Inspector面板直接修改
    public float moveSpeed = 5f;

    // 声明刚体变量，用来存储Player的刚体组件
    private Rigidbody rb;
    // 新增：是否可以跳跃
    private bool canJump = true;
    // 声明网格渲染器变量，用来修改物体颜色
    private MeshRenderer mr;

    void Start()
    {
        // 获取当前物体上的Rigidbody【刚体】组件
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // 获取键盘水平输入（A/D、左右方向键）
        float horizontalInput = Input.GetAxis("Horizontal");
        // 获取键盘垂直输入（W/S、上下方向键）
        float verticalInput = Input.GetAxis("Vertical");

        // 构建移动方向向量：X轴左右，Z轴前后，Y轴上下（不移动）
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        // 给刚体设置速度，正确写法：刚体velocity不需要乘Time.deltaTime！
        rb.velocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.velocity.y,
            moveDirection.z * moveSpeed
        );

        // 只有当canJump为true时才能跳
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            // 给刚体一个向上的力，力的大小是300
            rb.AddForce(Vector3.up * 300);
            // 跳完之后立刻禁止跳跃
            canJump = false;
        }
        // 按下J键，物体变成红色
        if (Input.GetKeyDown(KeyCode.J))
        {
            mr.material.color = Color.red;
        }

        // 按下K键，物体变回白色
        if (Input.GetKeyDown(KeyCode.K))
        {
            mr.material.color = Color.white;
        }
    }

    // 碰撞到地面时，恢复跳跃能力
    void OnCollisionEnter(Collision collision)
    {
        // 如果碰撞到的是地面（名字叫Plane）
        if (collision.gameObject.name == "Plane")
        {
            canJump = true;
        }
    }
}