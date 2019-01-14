using System.Drawing;

namespace ImageProcessing
{
    /*
        For images in color spaces such as Y'UV and its relatives, which are used in standard color TV and video systems 
        such as PAL, SECAM, and NTSC, a nonlinear luma component (Y') is calculated directly from gamma-compressed primary 
        intensities as a weighted sum, which, although not a perfect representation of the colorimetric luminance, can be 
        calculated more quickly without the gamma expansion and compression used in photometric/colorimetric calculations. 
        In the Y'UV and Y'IQ models used by PAL and NTSC, the rec601 luma (Y') component is computed as

        Y'=0.299R'+0.587G'+0.114B'
        where we use the prime to distinguish these nonlinear values from the sRGB nonlinear values (discussed above) which 
        use a somewhat different gamma compression formula, and from the linear RGB components. The ITU-R BT.709 standard 
        used for HDTV developed by the ATSC uses different color coefficients, computing the luma component as

        Y'=0.2126R'+0.7152G'+0.0722B'.
        Although these are numerically the same coefficients used in sRGB above, the effect is different because here they 
        are being applied directly to gamma-compressed values rather than to the linearized values. The ITU-R BT.2100 
        standard for HDR television uses yet different coefficients, computing the luma component as

        Y'=0.2627R'+0.6780G'+0.0593B'.

        Mix alfa in to include transparancy (down in alfa)
    */
    public static class GrayscaleConverter
    {
        public static float ConvertToGrayscaleV1(Color color)
        {
            return 0.299f * color.R + 0.587f * color.G + 0.114f * color.B;
        }

        public static float ConvertToGrayscaleV2(Color color)
        {
            return 0.2126f * color.R + 0.7152f * color.G + 0.0722f * color.B;
        }

        public static float ConvertToGrayscaleV3(Color color)
        {
            return 0.2627f * color.R + 0.6780f * color.G + 0.0593f * color.B;
        }
    }
}
