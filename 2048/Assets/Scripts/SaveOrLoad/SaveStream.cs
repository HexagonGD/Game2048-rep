using System.IO;
using UnityEngine;

namespace Game2048
{
    public class SaveStream
    {
        private readonly BinaryWriter _stream;

        public SaveStream(BinaryWriter stream)
        {
            _stream = stream;
        }

        public void Write(Vector3 vector)
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            _stream.Write(vector.x);
            _stream.Write(vector.y);
            _stream.Write(vector.z);
        }

        public void Write(Quaternion quaternion)
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            _stream.Write(quaternion.x);
            _stream.Write(quaternion.y);
            _stream.Write(quaternion.z);
            _stream.Write(quaternion.w);
        }

        public void Write(int number)
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            _stream.Write(number);
        }

        public void Write(float number)
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            _stream.Write(number);
        }

        public void Write(string str)
        {
            if (_stream == null)
            {
                throw new System.NullReferenceException("Файл не существует или не открыт");
            }

            _stream.Write(str);
        }
    }
}