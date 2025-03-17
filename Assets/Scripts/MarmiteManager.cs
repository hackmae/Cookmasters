using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MarmiteManager : MonoBehaviour
{
    public XRSocketInteractor socketPomme1;
    public XRSocketInteractor socketPomme2;
    public XRSocketInteractor socketPomme3;
    public GameObject compotePrefab;
    public Transform spawnPoint;

    private void Update()
    {
        compotePrefab.SetActive(false);
        if (SocketsPlein())
        {
            FaireCompote();
        }
    }

    bool SocketsPlein()
    {
        // Vérifie que chaque socket contient un objet sélectionné
        return socketPomme1.GetOldestInteractableSelected() != null &&
               socketPomme2.GetOldestInteractableSelected() != null &&
               socketPomme3.GetOldestInteractableSelected() != null;
    }

    void FaireCompote()
    {
        // Détruire les pommes dans les sockets si elles existent
        DestroyPomme(socketPomme1);
        DestroyPomme(socketPomme2);
        DestroyPomme(socketPomme3);

        // Faire apparaître la compote
        compotePrefab.SetActive(true);
        Instantiate(compotePrefab, spawnPoint.position, Quaternion.identity);
    }

    void DestroyPomme(XRSocketInteractor socket)
    {
        var interactable = socket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            // Caster en MonoBehaviour pour avoir accès à gameObject
            GameObject pomme = (interactable as MonoBehaviour)?.gameObject;
            if (pomme != null)
            {
                Destroy(pomme);
            }
        }
    }
}
