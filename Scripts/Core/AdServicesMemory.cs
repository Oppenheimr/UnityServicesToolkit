using System.Threading.Tasks;
using UnityServicesToolkit.Services.GoogleServices;
using UnityUtils.BaseClasses;

namespace UnityServicesToolkit.Core
{
    public class AdServicesMemory : Singleton<AdServicesMemory>
    {

        public static async Task Initialize()
        {
            await GoogleAds.Initialize();
            //Unity Ad vs other ad services
        }
    }
}