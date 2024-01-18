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

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    public Transform target;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();


       



    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(!target)
    
            {
                Destroy(gameObject);
                return;
            }

        Vector2 direction= (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;



        // Calcular la rotación hacia la dirección del objetivo
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplicar rotación al objeto visual (Transform)
        transform.rotation = Quaternion.Euler(0f, 0f, angle - -90f); // Ajustar el ángulo inicial según el sprite


        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(shootSound);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);

    }
   
}
