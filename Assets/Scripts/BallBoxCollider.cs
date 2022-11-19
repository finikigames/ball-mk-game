﻿using Extensions;
using UnityEngine;

namespace DefaultNamespace {
    public class BallBoxCollider : MonoBehaviour {
        private MeshFilter _meshRenderer;
        private Mesh _oldMesh;

        private ColliderType _type;
        
        private void Start() {
            _meshRenderer = gameObject.AddComponentLazy<MeshFilter>();
            _oldMesh = _meshRenderer.mesh;
            _meshRenderer.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            _type = gameObject.GetColliderType();
            
            gameObject.DelComponent<Collider>();
            gameObject.AddComponentLazy<BoxCollider>();
        }

        private void OnDisable() {
            _meshRenderer.mesh = _oldMesh;
            gameObject.DelComponent<Collider>();
            gameObject.AddColliderByType(_type);
        }
    }
}