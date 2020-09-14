using System;
using System.Numerics;
namespace TRICAL
{
    public class TRICAL : IDisposable
    {
        readonly TRICALSafeHandle handle;
        float[] ExpectedField { get; set; }

        // https://github.com/sfwa/TRICAL
        public TRICAL(float[] expectedField, float norm, float noise = 1.5f)
        {
            handle = TRICALWrapper.CreateTRICAL();

            TRICALWrapper.TRICAL_init(handle);
            TRICALWrapper.TRICAL_norm_set(handle, norm);
            TRICALWrapper.TRICAL_noise_set(handle, noise);
            ExpectedField = expectedField;
        }

        public float[] Update(float[] raw)
        {
            TRICALWrapper.TRICAL_estimate_update(handle, raw, ExpectedField);

            float[] calibrated_reading = new float[3];
            TRICALWrapper.TRICAL_measurement_calibrate(handle, raw, calibrated_reading);

            calibrated_reading[0] = TRICALWrapper.TRICAL_cx_get();
            calibrated_reading[1] = TRICALWrapper.TRICAL_cy_get();
            calibrated_reading[2] = TRICALWrapper.TRICAL_cz_get();

            return calibrated_reading;
        }

        public float GetNorm()
        {
            return TRICALWrapper.TRICAL_norm_get(handle);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (handle != null && !handle.IsInvalid)
                handle.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
