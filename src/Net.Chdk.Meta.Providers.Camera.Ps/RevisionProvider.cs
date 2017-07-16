using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;
using System.Collections.Generic;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    sealed class RevisionProvider : SingleProductProvider<IProductRevisionProvider>, IRevisionProvider
    {
        public RevisionProvider(IEnumerable<IProductRevisionProvider> innerProviders)
            : base(innerProviders)
        {
        }

        public RevisionData GetRevision(string revision, TreeRevisionData treeRevision, ListPlatformData list, TreePlatformData tree, string productName)
        {
            return GetInnerProvider(productName).GetRevision(revision, treeRevision, list, tree);
        }
    }
}
