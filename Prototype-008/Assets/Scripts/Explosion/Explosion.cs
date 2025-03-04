using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject _explosionLight;
    [SerializeField] private ParticleSystem _explosionParticle;
    [Header("Necessery")]
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
        VisualEffect();
        foreach (Collider obj in Objs)
        {
            Rigidbody objRigidbody;

            if (obj.TryGetComponent<Rigidbody>(out objRigidbody))
            {
                Vector3 direction = objRigidbody.position - _ePoint;
                float distance = Vector3.Distance(objRigidbody.position, _ePoint);
                float power = _pressure * Mathf.Pow((1 / distance), 2);

                objRigidbody.AddForce(direction * power,ForceMode.Impulse);
            }
            else print($"{obj.name} has no rigidbody!");
        }
        StartCoroutine(DestroyCoroutine(_explosionLight,0.1f));
    }

    private void VisualEffect()
    {
        _explosionLight.SetActive(true);
        _explosionParticle.Play();
    }

    private IEnumerator DestroyCoroutine(GameObject target,float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_ePoint, _radius);
        Gizmos.color = Color.red;
    }
}
