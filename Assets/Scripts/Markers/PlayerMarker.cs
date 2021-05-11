using System;
using Items;
using UnityEngine;

public class PlayerMarker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out BadItemsMarker badMarker) || other.gameObject.TryGetComponent(out RequiredItemsMarker requiredMarker)) 
        {
            new InitItems().Init(other);
            Destroy(other.gameObject); 
        }
        else if (other.gameObject.TryGetComponent(out DeadlyItemsMarker deadlyMarker))
        {
            new InitItems().Init(other);
        }
        else if (other.gameObject.TryGetComponent(out EndGameMarker endGameMarker))
        {
            Debug.Log("Уровень пройден");
        }
        else throw new Exception("Нет объектов с необходимыми компонентами");
    }
}
