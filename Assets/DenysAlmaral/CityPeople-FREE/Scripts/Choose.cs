using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Choose : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        // Varsay�lan olarak PlayerPrefs'ten karakter se�imini al
        index = PlayerPrefs.GetInt("CharacterSelected", 0);

        // Karakter listesini doldur
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // T�m karakterleri pasif yap
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // Ge�erli indeksi kontrol et ve karakteri aktif yap
        if (index >= 0 && index < characterList.Length)
        {
            characterList[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Index ge�ersiz! Varsay�lan karakter se�iliyor.");
            index = 0;
            if (characterList.Length > 0)
            {
                characterList[index].SetActive(true);
            }
        }
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
    }

    public void KarakteriSe�()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("city");
       
    }

}
