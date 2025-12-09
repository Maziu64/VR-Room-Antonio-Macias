using UnityEngine;
using System;

public class clock_function : MonoBehaviour
{
    public Transform hourHand;      // Manecilla de la hora
    public Transform minuteHand;    // Manecilla del minuto
    public Transform secondHand;    // Manecilla del segundo

    // Constantes para la rotación
    private const float hoursToDegrees = 30f;       // 360 grados / 12 horas
    private const float minutesToDegrees = 6f;      // 360 grados / 60 minutos
    private const float secondsToDegrees = 6f;      // 360 grados / 60 segundos
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la hora actual del sistema
        DateTime currentTime = DateTime.Now;

        // --- CÁLCULO DE ÁNGULOS ---

        // 1. Manecilla de la HORA
        // Multiplicamos las horas por 30 grados (360/12). 
        // Se añade un desplazamiento de 0.5 grados por cada minuto (30/60) 
        // para que la manecilla avance suavemente entre las horas.
        float currentHours = currentTime.Hour % 12 + (float)currentTime.Minute / 60f;
        float hourRotation = currentHours * hoursToDegrees;

        // 2. Manecilla del MINUTO
        // Multiplicamos los minutos por 6 grados (360/60).
        // Se añade un desplazamiento de 0.1 grados por cada segundo (6/60) 
        // para que la manecilla avance suavemente entre los minutos.
        float currentMinutes = currentTime.Minute + (float)currentTime.Second / 60f;
        float minuteRotation = currentMinutes * minutesToDegrees;

        // 3. Manecilla del SEGUNDO
        // Multiplicamos los segundos por 6 grados (360/60).
        float secondRotation = currentTime.Second * secondsToDegrees;

        // --- APLICACIÓN DE ROTACIÓN ---

        // La rotación se aplica en el eje Z o Y, dependiendo de cómo esté modelado el reloj.
        // Asumo el EJE Z para una rotación en el plano XY (como si el reloj estuviera en una pared).
        // Si tu reloj está en el suelo (plano XZ) y gira en el eje Y, cambia 'Vector3.forward' por 'Vector3.up'.

        // IMPORTANTE: Se usa la rotación NEGATIVA porque la rotación horaria (a favor de las agujas del reloj) 
        // en Unity generalmente corresponde a un ángulo NEGATIVO alrededor del eje de rotación.

        if (hourHand != null)
        {
            hourHand.localRotation = Quaternion.AngleAxis(-hourRotation, Vector3.forward);
        }

        if (minuteHand != null)
        {
            minuteHand.localRotation = Quaternion.AngleAxis(-minuteRotation, Vector3.forward);
        }

        if (secondHand != null)
        {
            secondHand.localRotation = Quaternion.AngleAxis(-secondRotation, Vector3.forward);
        }
    }
}
