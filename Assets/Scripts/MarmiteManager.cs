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
        // V�rifie que chaque socket contient un objet s�lectionn�
        return socketPomme1.GetOldestInteractableSelected() != null &&
               socketPomme2.GetOldestInteractableSelected() != null &&
               socketPomme3.GetOldestInteractableSelected() != null;
    }

    void FaireCompote()
    {
        // D�truire les pommes dans les sockets si elles existent
        DestroyPomme(socketPomme1);
        DestroyPomme(socketPomme2);
        DestroyPomme(socketPomme3);

        // Faire appara�tre la compote
        compotePrefab.SetActive(true);
        Instantiate(compotePrefab, spawnPoint.position, Quaternion.identity);
    }

    void DestroyPomme(XRSocketInteractor socket)
    {
        var interactable = socket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            // Caster en MonoBehaviour pour avoir acc�s � gameObject
            GameObject pomme = (interactable as MonoBehaviour)?.gameObject;
            if (pomme != null)
            {
                Destroy(pomme);
            }
        }
    }
}
