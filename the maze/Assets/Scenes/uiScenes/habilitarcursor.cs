using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilitarcursor : MonoBehaviour
{
    private bool cursorHabilitado = false;

    void Awake()
    {
        // Cambiar el estado del cursor al entrar en la escena
        cursorHabilitado = !cursorHabilitado; // Invertimos el estado para habilitar por defecto al entrar en la escena.

        // Habilitar o deshabilitar el cursor según el estado
        Cursor.lockState = cursorHabilitado ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = cursorHabilitado;
    }

    void Update()
    {
        // Verificar si se ha presionado una tecla (en este caso, la tecla "M")
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Cambiar el estado del cursor
            cursorHabilitado = !cursorHabilitado;

            // Habilitar o deshabilitar el cursor según el estado
            Cursor.lockState = cursorHabilitado ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = cursorHabilitado;
        }
    }
}