// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Crg7GAo3PDMQvHK8zTc7Ozs/Ojn/RF+0qLoY5Zv0yOw6XJ7/Bo4DaYIUOxV1Mph4/F/KhAWpczW1KczQ3sv72aqb/Efvl/mAVeehMyxnfbJH2GTpYE3o+XuaLrJTzFklGWJfMh+QOkNjitfT/HhZ/HeZFjxCFE0uGcW6JA1Kx6FOnquOvMki4P5C2MHDoAYBR9dVZ42wW9BrxuUdBPDUv7g7NToKuDswOLg7Ozq7ajM5FljSxs6BriQif8OgFibC04mBwsJucrhNdG+MofA8TWruYpF8ah4rmCYwhxTx4VQhcRrubdTjx7v2v2qqSdt2Iq5+tEVmMmPkcu9k6KGXHoKzo14hMZkxpvC37yhBL+4WNIgmU0UOA4yrZp7nzJT5ITg5Ozo7");
        private static int[] order = new int[] { 0,11,6,8,10,12,7,10,11,13,10,12,13,13,14 };
        private static int key = 58;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
