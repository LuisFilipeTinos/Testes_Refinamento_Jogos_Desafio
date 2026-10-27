using UnityEngine;

// Compatibilidade entre versões da Unity:
// a partir da Unity 6, "velocity" passou a se chamar "linearVelocity".
// Este arquivo NÃO faz parte da caça aos bugs.
public static class RigidbodyCompat
{
    public static Vector3 GetVelocity(Rigidbody rb)
    {
#if UNITY_6000_0_OR_NEWER
        return rb.linearVelocity;
#else
        return rb.velocity;
#endif
    }

    public static void SetVelocity(Rigidbody rb, Vector3 valor)
    {
#if UNITY_6000_0_OR_NEWER
        rb.linearVelocity = valor;
#else
        rb.velocity = valor;
#endif
    }
}
