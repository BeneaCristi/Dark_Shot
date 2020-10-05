using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    Player playerScript;
    public int healAmount;
    public GameObject effect;
    public GameObject effect1;
    public float lifeTime;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Wait());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerScript.Heal(healAmount);
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
