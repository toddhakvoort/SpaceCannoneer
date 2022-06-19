using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move bullet
        Vector3 pos = transform.position;
        pos.x += dir.x * Time.deltaTime;
        pos.y += dir.y * Time.deltaTime;
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void SetDirection(Vector2 newDir)
    {
        dir = newDir;
    }

    public void SetDamage(float newDamage)
    {
        Damage = newDamage;
    }
    public float GetDamage()
    {
        return Damage;
    }

    private Vector2 dir = Vector2.zero;
    private float Damage = 0.0f;
}
