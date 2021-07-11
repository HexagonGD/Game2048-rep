using System.IO;
using UnityEngine;

namespace Game2048
{
    public class LoadStream
    {
        private BinaryReader _stream;

        public LoadStream(BinaryReader stream)
        {
            _stream = stream;
        }

        public Vector3 ReadVector3()
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            Vector3 vector;
            vector.x = _stream.ReadSingle();
            vector.y = _stream.ReadSingle();
            vector.z = _stream.ReadSingle();
            return vector;
        }

        public Quaternion ReadQuaternion()
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            Quaternion quaternion;
            quaternion.x = _stream.ReadSingle();
            quaternion.y = _stream.ReadSingle();
            quaternion.z = _stream.ReadSingle();
            quaternion.w = _stream.ReadSingle();
            return quaternion;
        }

        public int ReadInt()
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            return _stream.ReadInt32();
        }

        public float ReadFloat()
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            return _stream.ReadSingle();
        }

        public string ReadString()
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            return _stream.ReadString();
        }
    }
}