using UnityEngine;

public class CookableItem : MonoBehaviour
{
    public float tiempoParaCocinar = 5f;
    public float tiempoParaQuemar = 8f;

    private float tiempoActual = 0f;
    private bool estaCocinando = false;
    private ItemInstance itemInstance;

    private void Start()
    {
        itemInstance = GetComponent<ItemInstance>();
    }

    private void Update()
    {
        if (!estaCocinando || itemInstance == null) return;

        tiempoActual += Time.deltaTime;

        if (tiempoActual >= tiempoParaQuemar)
        {
            CambiarAEstado(itemInstance.itemData.quemado);
        }
        else if (tiempoActual >= tiempoParaCocinar)
        {
            CambiarAEstado(itemInstance.itemData.cocido);
        }
    }

    public void EmpezarCoccion() => estaCocinando = true;
    public void DetenerCoccion() => estaCocinando = false;

    private void CambiarAEstado(ItemSO nuevoEstado)
    {
        if (nuevoEstado == null) return;

        GameObject nuevo = Instantiate(nuevoEstado.prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
