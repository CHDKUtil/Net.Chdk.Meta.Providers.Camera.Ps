using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    public abstract class RevisionProvider : IRevisionProvider
    {
        public abstract RevisionData GetRevision(string revision, TreeRevisionData treeRevision, ListPlatformData list, TreePlatformData tree);

        protected static RevisionData GetRevision(string revision)
        {
            return new RevisionData
            {
                Revision = revision,
            };
        }
    }
}
