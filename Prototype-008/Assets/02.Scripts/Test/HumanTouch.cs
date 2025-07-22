using UnityEngine;

public class HumanTouch : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
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
