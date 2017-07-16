using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    public abstract class ProductRevisionProvider : IProductRevisionProvider
    {
        public abstract RevisionData GetRevision(string revision, TreeRevisionData treeRevision, ListPlatformData list, TreePlatformData tree);

        public abstract string ProductName { get; }

        protected static RevisionData GetRevision(string revision)
        {
            return new RevisionData
            {
                Revision = revision,
            };
        }
    }
}
