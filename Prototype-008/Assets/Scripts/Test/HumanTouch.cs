using UnityEngine;

public class HumanTouch : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody rigid;
    private Vector3 moveDir;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDir = (moveDir + Vector3.left).normalized;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDir = (moveDir + Vector3.right).normalized;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDir = (moveDir + Vector3.forward).normalized;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDir = (moveDir + Vector3.back).normalized;
        }
        rigid.AddForce(moveDir * moveSpeed);
        moveDir = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ITouchable>(out ITouchable toucable))
        {
            toucable.Touched();
        }
        else
        {
            print("터치못함 ㅅㄱ");
        }
    }
}
