using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_enemy_spawner : MonoBehaviour
{
    public GameObject enemy_array_1;
    public GameObject enemy_array_2;

    public GameObject[] formation_array;

    private int selected_array;
    // Start is called before the first frame update
    void Start()
    {
        formation_array[0] = enemy_array_1;
        formation_array[1] = enemy_array_2;

        foreach (GameObject enemy_group in formation_array)
        {
            enemy_group.SetActive(false);
        }

        selected_array = Random.Range(0, 2);
        formation_array[selected_array].SetActive(true);
    }

}
