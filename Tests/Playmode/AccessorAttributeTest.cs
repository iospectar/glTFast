using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GLTFast.Tests
{
    public class AccessorAttributeTest
    {
        private string link =
            "https://raw.githubusercontent.com/microsoft/MixedRealityToolkit-Unity/main/Assets/MRTK/Examples/Demos/Gltf/Models/Cube/GLB/cube-with-custom-attr.glb";

        private GltfAsset gltfAsset;
        
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            var gameObject = new GameObject();
            gltfAsset = gameObject.AddComponent<GltfAsset>();
            gltfImport = new GltfImport();
            var task = gltfImport.Load(link);
            
            while (!task.IsCompleted)
            {
                yield return null;
            }
        }

        private GltfImport gltfImport;

        [TearDown]
        public void TearDown()
        {
            gltfImport.Dispose();
            gltfAsset.Dispose();
        }
        
        [Test]
        public void GetCustomAttributesArray()
        {
            var primitives = gltfImport
                .GetSourceRoot()
                .meshes
                .First()
                .primitives
                .First();
            Debug.Log(primitives);

            // .attributes.TryGetValue("_CUSTOM_ATTR",
            //    out var attributeIndex);
            // var accessor = gltfAsset.GetAccessor(attributeIndex);
            // var intArray = accessor.GetIntArray(false);
            // foreach (var item in intArray)
            // {
            //     Assert.AreEqual(10, item);
            // }
        }

        [Test]
        public void GetGenericAttributesArray()
        {
            // var index = gltfAsset.GetGltfMeshes()
            //     .First()
            //     .primitives.First()
            //     .attributes.POSITION;
            //
            // var accessor = gltfAsset.GetAccessor(index);
            // var posArray = accessor.GetVector3Array(false);
            // foreach (var position in posArray)
            // {
            //     Assert.AreNotEqual(Vector3.zero, position);
            // }
        }
    }
}
