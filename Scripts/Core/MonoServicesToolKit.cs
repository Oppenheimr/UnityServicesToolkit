using UnityEngine;
using UnityUtils.BaseClasses;
using UnityUtils.Extensions;

namespace UnityServicesToolkit.Core
{
    /// <summary>
    /// En.
    /// This class is created at the beginning of the game and lives until the end of the game.
    /// The purpose of this class is to hold references to classes that will be created at the beginning of the game and will live until the end of the game.
    /// This class will be used when any component written for Unity needs to keep a reference in the scene.
    /// Tr.
    /// Bu sınıf oyunun başında oluşturulur ve oyunun sonuna kadar yaşar.
    /// Bu sınıfın amacı, oyunun başında oluşturulacak olan ve oyunun sonuna kadar yaşayacak olan sınıfların referanslarını tutmaktır.
    /// Bu sınıf herhangi Unity için yazılmış componentin sahnede bir referansı tutulması gerektiğinde kullanılacak
    /// </summary>
    public class MonoServicesToolKit : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            // Create an empty GameObject
            GameObject gameObject = new GameObject("ServicesToolKit");
            // Add this Component
            gameObject.AddComponent<MonoServicesToolKit>();
        }

        protected async void Awake()
        {
            if (!gameObject.DontDestroyOnLoadIfSingle<MonoServicesToolKit>())
                return;
            Memory.MonoServicesToolKit = this;
            
            //TO DO : Bu fonksyon asenkron olacak bitince load scene geçecek
            await Memory.Initialize();
        }
    }
}