using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class PsCameraProvider : CameraProvider<PsCameraData, PsCameraModelData, PsCardData>, IPsCameraProvider
    {
        private IAltProvider AltProvider { get; }

        public PsCameraProvider(IEncodingProvider encodingProvider, IBootProvider bootProvider, IPsCardProvider cardProvider, IAltProvider altProvider)
            : base(encodingProvider, bootProvider, cardProvider)
        {
            AltProvider = altProvider;
        }

        public override PsCameraData GetCamera(uint modelId, string platform, ListPlatformData list, TreePlatformData tree)
        {
            var camera = base.GetCamera(modelId, platform, list, tree);
            camera.Alt = AltProvider.GetAlt(platform, tree.Alt);
            return camera;
        }
    }
}
