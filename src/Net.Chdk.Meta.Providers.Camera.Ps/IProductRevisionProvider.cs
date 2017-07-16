using Net.Chdk.Meta.Model.Camera.Ps;
using Net.Chdk.Meta.Model.CameraList;
using Net.Chdk.Meta.Model.CameraTree;

namespace Net.Chdk.Meta.Providers.Camera.Ps
{
    public interface IProductRevisionProvider : IProductNameProvider
    {
        RevisionData GetRevision(string revision, TreeRevisionData treeRevision, ListPlatformData list, TreePlatformData tree);
    }
}
