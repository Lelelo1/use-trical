using System;
using Microsoft.Win32.SafeHandles;

namespace TRICAL
{
    internal class TRICALSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public TRICALSafeHandle() : base(true) { }

        public IntPtr Ptr => this.handle;

        protected override bool ReleaseHandle()
        {
            // TODO: Release the handle here

            // add dispose method in the wrapper, TRICAL.cs. (documentation sample have both ceate and dispose - so they might have to be added in TRICAL.h) 

            return true;
        }
    }
}
