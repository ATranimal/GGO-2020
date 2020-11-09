using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
