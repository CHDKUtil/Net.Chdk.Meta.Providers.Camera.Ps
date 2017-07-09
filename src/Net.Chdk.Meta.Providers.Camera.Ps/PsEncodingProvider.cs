using Net.Chdk.Meta.Model.Camera;
using System.Linq;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class PsEncodingProvider : EncodingProvider
    {
        #region Fields

        private IBootMetaProvider BootProvider { get; }

        #endregion

        #region Constructor

        public PsEncodingProvider(IBootMetaProvider bootProvider)
        {
            BootProvider = bootProvider;
        }

        #endregion

        #region Encodings

        protected override EncodingData[] GetEncodings()
        {
            var length = BootProvider.Offsets != null
                ? BootProvider.Offsets.Length
                : 1;
            return Enumerable.Range(0, length)
                .Select(GetOffsets)
                .ToArray();
        }

        private EncodingData GetOffsets(int i)
        {
            return i > 0
                ? GetEncoding(BootProvider.Offsets[i - 1])
                : EmptyEncoding;
        }

        private static EncodingData GetEncoding(int[] offsets)
        {
            return new EncodingData
            {
                Name = "dancingbits",
                Data = GetOffsets(offsets)
            };
        }

        private static uint? GetOffsets(int[] offsets)
        {
            var uOffsets = 0u;
            for (int index = 0; index < offsets.Length; index++)
                uOffsets += (uint)offsets[index] << (index << 2);
            return uOffsets;
        }

        #endregion
    }
}
