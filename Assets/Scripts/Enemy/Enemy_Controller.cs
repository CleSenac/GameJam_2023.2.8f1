using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Enemy_Controller : MonoBehaviour
{
    private float currentHealth;
    public int maxHealth = 10;
    GameObject particle;

    private Animator animator;

    Image healthbarTransform;

    public ParticleCollisionEvent hitParticle;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        healthbarTransform = GameObject.Find("Canvas").transform.Find("HealthBar").transform.Find("Health").GetComponent<Image>();
        particle = transform.Find("FX_BloodSplatter").gameObject;
    }

    void Update()
    {
        // Verificar se há toques na tela
        if (Input.touchCount > 0)
        {
            // Verificar se o toque na tela acabou de acontecer
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Chamada de função para decrementar a vida
                DecrementLife();
            }
        }
    }

    // Função para decrementar a vida
    void DecrementLife()
    {
        // Verificar se a vida é maior que 0 para evitar vida negativa
        if (currentHealth > 0)
        {
            // Decrementar a vida em 1
            currentHealth--;
            healthbarTransform.fillAmount = currentHealth/10f;

            // Exibir a vida atual do inimigo no console (opcional)
            Debug.Log("Life: " + currentHealth);

            animator.SetTrigger("Damage");

            // Se a vida for 0, destruir o objeto do inimigo (opcional)
            if (currentHealth == 0)
            {
                Player_controller.gold = Player_controller.gold+5;
                particle.SetActive(true);
                animator.SetTrigger("Death");
                Destroy(gameObject,2);
                healthbarTransform.fillAmount = 1;
            }
        }
    }
}
