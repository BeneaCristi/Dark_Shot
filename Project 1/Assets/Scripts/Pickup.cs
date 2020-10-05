using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Weapon weaponToEquip;
    public GameObject effect;
    public GameObject effect1;
    public float lifeTime;


    private void Start()
    {
        StartCoroutine(Wait());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, lifeTime);
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        Instantiate(effect1, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
