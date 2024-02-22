using System.Threading.Tasks;

namespace UnityServicesToolkit.Core
{
    public static class Memory
    {
        public static MonoServicesToolKit MonoServicesToolKit { get; set; }
        
        public static async Task Initialize()
        {
            await FirebaseMemory.Initialize();
            await AdServicesMemory.Initialize();
            await UnityServicesMemory.Initialize();;
        }
    }
}