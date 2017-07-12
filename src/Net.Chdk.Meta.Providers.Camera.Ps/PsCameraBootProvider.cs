namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class PsCameraBootProvider : CameraBootProvider
    {
        private const uint MinFat32ModelId = 0x2980000;

        protected override string GetBootFileSystem(uint modelId)
        {
            return modelId >= MinFat32ModelId
                ? "FAT32"
                : "FAT";
        }
    }
}
