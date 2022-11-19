using Services.Base;

namespace Services {
    public class CheckMobileService : BaseSingleton<CheckMobileService> {
#if !UNITY_EDITOR && UNITY_WEBGL
        [System.Runtime.InteropServices.DllImport("__Internal")]
        public static extern bool IsMobile();
#endif

        public bool CheckIfMobile()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
#else
            return false;
#endif
        }
    }
}