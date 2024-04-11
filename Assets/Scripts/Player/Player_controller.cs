using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public static int gold = 0;
    private Animator animator; // Refer�ncia para o componente Animator

    public static int hit = 1; // Vari�vel para armazenar os toques
    public TextMeshProUGUI hitText; // Refer�ncia ao campo de texto na interface do usu�rio
    public TextMeshProUGUI numCoin; // Refer�ncia ao campo de texto na interface do usu�rio

    void Start()
    {
        // Obt�m o componente Animator do GameObject
        hitText.text = hit.ToString();
        numCoin.text = hit.ToString();
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartCoroutine(ShowAndHideHitText());
            // Ativa a anima��o de ataque ao tocar na tela
            animator.SetTrigger("Attack");
        }
        numCoin.text = gold.ToString();
        Debug.Log("Hit = " + hit);
    }

    IEnumerator ShowAndHideHitText()
    {
        // Mostra o texto
        hitText.enabled = true;

        // Move o texto para cima
        float duration = 0.3f;
        float elapsedTime = 0f;
        RectTransform rectTransform = hitText.GetComponent<RectTransform>();
        Vector3 initialPosition = rectTransform.localPosition;
        Vector3 targetPosition = initialPosition + Vector3.up * 10f; // Move 20 unidades para cima

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            rectTransform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        // Espera 0.5 segundos
        yield return new WaitForSeconds(0.2f);

        // Esconde o texto
        hitText.enabled = false;

        // Define a posi��o onde o texto ser� reativado
        rectTransform.localPosition = new Vector3(-153f, 794f, 0f); // Substitua pelos valores desejados
    }
}