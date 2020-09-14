using System;
using System.Runtime.InteropServices;
namespace TRICAL
{

internal static class TRICALWrapper
    {
#if Android
        const string DllName = "libTRICAL.so";
#else
        const string DllName = "__Internal";
#endif
        [DllImport(DllName, EntryPoint = "CreateTRICAL")]
        internal static extern TRICALSafeHandle CreateTRICAL();

        [DllImport(DllName, EntryPoint = "DisposeTRICAL")]
        internal static extern void DisposeTRICAL(IntPtr ptr);


        [DllImport(DllName, EntryPoint = "TRICAL_init")]
        internal static extern void TRICAL_init(TRICALSafeHandle ptr);

        [DllImport(DllName, EntryPoint = "TRICAL_reset")]
        internal static extern void TRICAL_reset(TRICALSafeHandle ptr);

        [DllImport(DllName, EntryPoint = "TRICAL_norm_set")]
        internal static extern void TRICAL_norm_set(TRICALSafeHandle ptr, float norm);

        [DllImport(DllName, EntryPoint = "TRICAL_norm_get")]
        internal static extern float TRICAL_norm_get(TRICALSafeHandle ptr);

        [DllImport(DllName, EntryPoint = "TRICAL_noise_set")]
        internal static extern void TRICAL_noise_set(TRICALSafeHandle ptr, float noise);

        [DllImport(DllName, EntryPoint = "TRICAL_noise_get")]
        internal static extern float TRICAL_noise_get(TRICALSafeHandle ptr);

        [DllImport(DllName, EntryPoint = "TRICAL_measurement_count_get")]
        internal static extern int TRICAL_measurement_count_get(TRICALSafeHandle ptr);

        [DllImport(DllName, EntryPoint = "TRICAL_estimate_update")]
        internal static extern void TRICAL_estimate_update(TRICALSafeHandle ptr, float[] measurement, float[] reference_field);

        [DllImport(DllName, EntryPoint = "TRICAL_estimate_get")]
        internal static extern void TTRICAL_estimate_get(TRICALSafeHandle ptr, float[] bias_estimate, float[] scale_estimate);

        [DllImport(DllName, EntryPoint = "TRICAL_estimate_get_ext")]
        internal static extern void TRICAL_estimate_get_ext(TRICALSafeHandle ptr, float[] bias_estimate, float[] scale_estimate, float[] bias_estimate_variance, float[] scale_estimate_variance);

        [DllImport(DllName, EntryPoint = "TRICAL_measurement_calibrate")]
        internal static extern void TRICAL_measurement_calibrate(TRICALSafeHandle ptr, float[] measurement, float[] calibrated_measurement);

        
        // extra, just to get calibrated vector
        [DllImport(DllName, EntryPoint = "TRICAL_cx_get")]
        internal static extern float TRICAL_cx_get();

        [DllImport(DllName, EntryPoint = "TRICAL_cy_get")]
        internal static extern float TRICAL_cy_get();

        [DllImport(DllName, EntryPoint = "TRICAL_cz_get")]
        internal static extern float TRICAL_cz_get();
        
    }
}
