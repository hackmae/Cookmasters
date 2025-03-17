using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CutManager : MonoBehaviour
{
    public XRSocketInteractor[] sockets; // Sockets pour les pommes normales
    public GameObject pommeColoreePrefab;
    public Transform spawnPoint;

    private List<GameObject> pommesDansSockets = new List<GameObject>();
    private int pommesCoupees = 0;

    void Start()
    {
        // Trouve automatiquement les pommes dans les sockets
        foreach (var socket in sockets)
        {
            var interactable = socket.GetOldestInteractableSelected();
            if (interactable != null)
            {
                // Ajoute l'objet sélectionné à la liste des pommes
                GameObject pomme = (interactable as MonoBehaviour)?.gameObject;
                if (pomme != null)
                {
                    pommesDansSockets.Add(pomme);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pomme") && pommesDansSockets.Contains(other.gameObject))
        {
            CouperPomme(other.gameObject);
        }
    }

    void CouperPomme(GameObject pomme)
    {
        // Si la pomme est dans la liste supprime-la
        if (pommesDansSockets.Contains(pomme))
        {
            pommesDansSockets.Remove(pomme);
            Destroy(pomme);
            pommesCoupees++;

            if (pommesCoupees >= 3)
            {
                FaireApparaitrePommesColorees();
                pommesCoupees = 0;
            }
        }
    }

    void FaireApparaitrePommesColorees()
    {
        // Faire apparaître trois pommes colorées
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = spawnPoint.position + new Vector3(i * 0.3f, 0, 0);
            Instantiate(pommeColoreePrefab, position, Quaternion.identity);
        }
        Debug.Log("Pommes colorées créées !");
    }
}
