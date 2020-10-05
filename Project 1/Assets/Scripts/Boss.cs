using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    private int halfHealth;
    private Animator anim;
    public int damage;
    public GameObject effect;

    private Slider healthbar;

    private SceneTranzitions sceneTransitions;


    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        healthbar = FindObjectOfType<Slider>();
        healthbar.maxValue = health;
        healthbar.value = health;
        sceneTransitions = FindObjectOfType<SceneTranzitions>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthbar.value = health;
        if (health <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
            healthbar.gameObject.SetActive(false);
            sceneTransitions.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("Stage 2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy,transform.position + new UnityEngine.Vector3(spawnOffset, spawnOffset, 0),transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
