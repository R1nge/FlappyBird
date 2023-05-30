using UnityEngine;

namespace Interfaces
{
    public interface IMovable
    {
        public Vector3 Direction { get; set; }
        public float Speed { get; set; }
        public void Move();
    }
}