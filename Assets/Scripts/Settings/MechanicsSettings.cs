using System;
using System.Collections.Generic;

namespace DefaultNamespace.Settings {
    public class MechanicsSettings {
        public Dictionary<MechanicType, Type> Mechanics;

        public List<Type> FormMechanics;

        public void Initialize() {
            Mechanics = new Dictionary<MechanicType, Type>();
            Mechanics.Add(MechanicType.Move, typeof(BallMovementPhysicsVelocity));
            Mechanics.Add(MechanicType.Jump, typeof(BallJump));
            Mechanics.Add(MechanicType.DoubleJump, typeof(BallDoubleJump));
            Mechanics.Add(MechanicType.Box, typeof(BallBoxCollider));
            Mechanics.Add(MechanicType.Tetra, typeof(BallTetraCollider));
            Mechanics.Add(MechanicType.Sphere, typeof(BallSphereCollider));
            Mechanics.Add(MechanicType.DownScale, typeof(BallDownScale));
            Mechanics.Add(MechanicType.UpScale, typeof(BallUpScale));
            Mechanics.Add(MechanicType.MovementInverse, typeof(BallMovementInverse));
            Mechanics.Add(MechanicType.WallBouncy, typeof(BallWallBouncy));
            Mechanics.Add(MechanicType.WaterDown, typeof(BallWaterDownFloat));
            Mechanics.Add(MechanicType.WaterUp, typeof(BallWaterUpFloat));

            FormMechanics = new List<Type>();
            FormMechanics.Add(typeof(BallBoxCollider));
            FormMechanics.Add(typeof(BallTetraCollider));
            FormMechanics.Add(typeof(BallSphereCollider));
        }
    }
}