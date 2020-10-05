using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public int health;
    public Transform RightHand;

    private Rigidbody2D rb;
    private Animator anim;
    public Animator hurtAnim;

    public Image[] hearts;
    public Sprite fullHeatrs;
    public Sprite emptyHearts;
     

    private Vector2 moveAmount;

    private SceneTranzitions sceneTransitions;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransitions = FindObjectOfType<SceneTranzitions>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransitions.LoadScene("Lose");
        }
    }
    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, RightHand.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i=0; i< hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeatrs;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if(health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }


}
