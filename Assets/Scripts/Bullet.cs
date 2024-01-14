using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    public Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(!target) return;

        Vector2 direction= (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;

        // Calcular la rotaci�n hacia la direcci�n del objetivo
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotaci�n al objeto visual (Transform)
        transform.rotation = Quaternion.Euler(0f, 0f, angle - -90f); // Ajustar el �ngulo inicial seg�n el sprite

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);

    }
   
}
