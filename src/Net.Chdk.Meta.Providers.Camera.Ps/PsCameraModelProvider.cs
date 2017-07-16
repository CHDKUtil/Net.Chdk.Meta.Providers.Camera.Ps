using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;
using System.Collections.Generic;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class PsCameraModelProvider : CameraModelProvider<PsCameraModelData>, IPsCameraModelProvider
    {
        private IRevisionProvider RevisionProvider { get; }

        public PsCameraModelProvider(IRevisionProvider revisionProvider, ICameraModelValidator modelValidator)
            : base(modelValidator)
        {
            RevisionProvider = revisionProvider;
        }

        public override PsCameraModelData GetModel(string platform, string[] names, ListPlatformData list, TreePlatformData tree, string productName)
        {
            var model = base.GetModel(platform, names, list, tree, productName);
            model.Revisions = GetRevisions(platform, list, tree, productName);
            return model;
        }

        private IDictionary<string, RevisionData> GetRevisions(string platform, ListPlatformData list, TreePlatformData tree, string productName)
        {
            var revisions = new SortedDictionary<string, RevisionData>();
            foreach (var kvp in tree.Revisions)
            {
                var revision = RevisionProvider.GetRevision(kvp.Key, kvp.Value, list, tree, productName);
                if (revision != null)
                {
                    var revisionKey = GetRevisionKey(kvp.Key);
                    revisions.Add(revisionKey, revision);
                }
            }
            return revisions;
        }

        private static string GetRevisionKey(string revisionStr)
        {
            var revision = GetFirmwareRevision(revisionStr);
            return $"0x{revision:x}";
        }

        private static uint GetFirmwareRevision(string revision)
        {
            if (revision == null)
                return 0;
            return
                (uint)((revision[0] - 0x30) << 24) +
                (uint)((revision[1] - 0x30) << 20) +
                (uint)((revision[2] - 0x30) << 16) +
                (uint)((revision[3] - 0x60) << 8);
        }
    }
}
