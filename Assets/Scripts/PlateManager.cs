using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateManager : MonoBehaviour
{
    public XRSocketInteractor socketCompote;
    public XRSocketInteractor socketCrepe;
    public GameObject repasPrefab;
    public Transform spawnPoint;
    public GameObject bonapp;

    private bool repasFait = false;

    private void Update()
    {
        repasPrefab.SetActive(false);
        if (SocketsPlein() && !repasFait)
        {
            FaireRepas();
            repasFait = true;
        }
    }

    bool SocketsPlein()
    {
        // V�rifie que chaque socket contient un objet s�lectionn�
        return socketCompote.GetOldestInteractableSelected() != null &&
               socketCrepe.GetOldestInteractableSelected() != null;
    }

    void FaireRepas()
    {
        // D�truire les objets dans les sockets
        DestroyObjet(socketCompote);
        DestroyObjet(socketCrepe);
        bonapp.SetActive(true);

        // Faire appara�tre le repas
        repasPrefab.SetActive(true);
        Instantiate(repasPrefab, spawnPoint.position, Quaternion.identity);
    }

    void DestroyObjet(XRSocketInteractor socket)
    {
        var interactable = socket.GetOldestInteractableSelected();
        if (interactable != null)
        {
            // Caster en MonoBehaviour pour acc�der au GameObject
            GameObject obj = (interactable as MonoBehaviour)?.gameObject;
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
}
