using NUnit.Framework;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private ExplodeValueSO valueSO;
    private Vector3 _ePoint;

    private float _radius;
    private float _pressure;
    public void Explode(Vector3 explodePoint)
    {
        _radius = valueSO.Radius;
        _pressure = valueSO.Pressure;

        Collider[] effectableObj = Physics.OverlapSphere(_ePoint, _radius);

        EfterEffect(effectableObj);
    }

    private void EfterEffect(Collider[] Objs)
    {
        foreach (Collider obj in Objs)
        {
            Rigidbody objRigidbody;

            if (obj.TryGetComponent<Rigidbody>(out objRigidbody))
            {
                Vector3 direction = objRigidbody.position - _ePoint;
                float distance = Vector3.Distance(objRigidbody.position, _ePoint);
                float power = _pressure * Mathf.Pow((2/distance),2);

                objRigidbody.AddForce(direction * power,ForceMode.Impulse);
            }
            else print($"{obj.name} has no rigidbody!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_ePoint, _radius);
        Gizmos.color = Color.red;
    }
}
