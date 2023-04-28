using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class myscript : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public List<GameObject> gameObjectsList;
    public Transform spawnPoint;

    private GameObject currentGameObject;

    private void Start()
    {
        // Effacer les options du menu d�roulant existant
        dropdown.ClearOptions();

        // Ajouter les noms des objets de jeu dans une liste de cha�nes
        List<string> gameObjectNames = new List<string>();
        foreach (GameObject go in gameObjectsList)
        {
            gameObjectNames.Add(go.name);
        }

        // Ajouter les options de menu d�roulant avec les noms des objets de jeu
        dropdown.AddOptions(gameObjectNames);

        // Ajouter un �couteur d'�v�nement pour le changement de s�lection du menu d�roulant
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
    }

    private void OnDropdownValueChanged()
    {
        // D�truire l'objet de jeu pr�c�dent s'il en existe un
        if (currentGameObject != null)
        {
            Destroy(currentGameObject);
        }

        // Instancier le nouvel objet de jeu s�lectionn� dans le menu d�roulant
        currentGameObject = Instantiate(gameObjectsList[dropdown.value], spawnPoint.position, Quaternion.identity);
    }
}
