using System.Threading.Tasks;
using UnityEngine;

public class Natasha : MonoBehaviour
{
    private async void Awake()
    {
        await Task.Delay(100);
        print("Natasha");
    }
}
