using MudBlazor;
using MudBlazor.Utilities;

namespace CarbonNow.Web.Layout
{
    public sealed class CarbonNowPalette : PaletteDark
    {

        private CarbonNowPalette() 
        {
            Primary = new MudColor("#333333");
            Secondary = new MudColor("#F4F1E9");
            Tertiary = new MudColor("#8ECF30");
        }

        public static CarbonNowPalette CreatePallete => new();

    }
}
