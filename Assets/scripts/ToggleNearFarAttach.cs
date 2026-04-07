using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToggleNearFarAttach : MonoBehaviour
{
    [Header("Configuración de Interacción")]
    [Tooltip("Arrastra aquí el GameObject que contiene el componente NearFarInteractor.")]
    public NearFarInteractor nearFarInteractor;

    /// <summary>
    /// Activa o desactiva el modo de agarre a distancia.
    /// Este método debe asignarse en el evento "On Value Changed" del Toggle (Dynamic bool).
    /// </summary>
    /// <param name="isEnabled">True para activar el agarre a distancia, False para desactivarlo.</param>
    public void SetFarAttachMode(bool isEnabled)
    {
        if (nearFarInteractor != null)
        {
            // Solo activamos/desactivamos la proyección a distancia (Far Casting)
            // Así, el agarre cercano (Near Casting) seguirá funcionando siempre.
            nearFarInteractor.enableFarCasting = isEnabled;
        }
        else
        {
            Debug.LogWarning("No has asignado el componente NearFarInteractor en el script ToggleNearFarAttach.", this);
        }
    }
}