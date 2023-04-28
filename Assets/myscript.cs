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
        // Effacer les options du menu déroulant existant
        dropdown.ClearOptions();

        // Ajouter les noms des objets de jeu dans une liste de chaînes
        List<string> gameObjectNames = new List<string>();
        foreach (GameObject go in gameObjectsList)
        {
            gameObjectNames.Add(go.name);
        }

        // Ajouter les options de menu déroulant avec les noms des objets de jeu
        dropdown.AddOptions(gameObjectNames);

        // Ajouter un écouteur d'événement pour le changement de sélection du menu déroulant
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
    }

    private void OnDropdownValueChanged()
    {
        // Détruire l'objet de jeu précédent s'il en existe un
        if (currentGameObject != null)
        {
            Destroy(currentGameObject);
        }

        // Instancier le nouvel objet de jeu sélectionné dans le menu déroulant
        currentGameObject = Instantiate(gameObjectsList[dropdown.value], spawnPoint.position, Quaternion.identity);
    }
}
