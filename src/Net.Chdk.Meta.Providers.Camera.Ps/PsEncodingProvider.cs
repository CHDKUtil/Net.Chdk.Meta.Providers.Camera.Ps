using Net.Chdk.Meta.Model.Camera;
using Net.Chdk.Model.Category;
using System.Linq;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class PsEncodingProvider : EncodingProvider
    {
        #region Fields

        private IBootMetaProvider BootProvider { get; }
        private CategoryInfo Category { get; }

        #endregion

        #region Constructor

        public PsEncodingProvider(IBootMetaProvider bootProvider)
        {
            BootProvider = bootProvider;
            Category = new CategoryInfo
            {
                Name = "PS"
            };
        }

        #endregion

        #region Encodings

        protected override EncodingData[] GetEncodings()
        {
            var offsets = BootProvider.GetOffsets(Category);
            var length = offsets != null
                ? offsets.Length
                : 1;
            return Enumerable.Range(0, length)
                .Select(i => GetOffsets(offsets, i))
                .ToArray();
        }

        private EncodingData GetOffsets(int[][] offsets, int i)
        {
            return i > 0
                ? GetEncoding(offsets[i - 1])
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
