using System.ComponentModel;
using UnityEngine;

public class ExplosionExcuter : MonoBehaviour
{
    [SerializeField] private GameObject targetGameobject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Explosion explosionManager;
            if (!targetGameobject.TryGetComponent<Explosion>(out explosionManager))
            {
                print("target has no ExplosionManager!");
                return;
            }
            explosionManager.Explode(targetGameobject.transform.position);
        }
    }
}
