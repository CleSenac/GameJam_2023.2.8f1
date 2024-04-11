using System.Collections;
using UnityEngine;

public class Mob_spawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Refer�ncia ao prefab que voc� deseja instanciar

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(1.0f); // Aguarda por 1 segundo antes de instanciar o prefab

        if (!GameObject.FindWithTag("Enemy"))
        {
            // Instancia o prefab na posi��o do objeto Mob_spawn e com a rota��o padr�o
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        StartCoroutine(SpawnPrefab());
    }
}

