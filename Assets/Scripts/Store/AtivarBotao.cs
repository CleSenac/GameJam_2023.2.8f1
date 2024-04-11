using UnityEngine;
using UnityEngine.UI;

public class AtivarBotao : MonoBehaviour
{
    public Button botao;

    void Start()
    {
        // Adiciona um listener ao evento de clique do botão
        botao.onClick.AddListener(Ativar);
    }

    // Método para ativar o botão
    public void Ativar()
    {
        if (Player_controller.gold >= 10)
        {
            Player_controller.hit++;
            botao.interactable = true;
            Player_controller.gold = Player_controller.gold - 10;
        }        
    }
}