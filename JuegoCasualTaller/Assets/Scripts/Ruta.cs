using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public Paso PasoFinal;
    public List<Paso> PasosEnRuta;
    public PlayerMovementAI playerMovement;


    public void Iniciar()
    {
        Reset();
        StartCoroutine(Ejecutar());
    }
    public IEnumerator Ejecutar()
    {
        foreach (Paso p in PasosEnRuta)
        {
            StartCoroutine(p.Ejecutar());
            yield return new WaitWhile(() => p.completado == false);
            //hay minijuego?
        }

        StartCoroutine(PasoFinal.Ejecutar());
        yield return new WaitWhile(() => PasoFinal.completado == false);

        yield return new WaitForSeconds(0f);
        playerMovement.procesoIniciado = false;
    }

    public void Reset()
    {
        PasoFinal.completado = false;
        foreach (Paso p in PasosEnRuta)
        {
            p.completado = false;
        }
    }

}
