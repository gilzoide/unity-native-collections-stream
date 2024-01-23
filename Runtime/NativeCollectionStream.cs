using System;
using System.IO;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeCollectionReadOnlyStream<TList> : Stream
        where TList : INativeList<byte>
    {
        protected TList _list;
        protected int _position;

        public NativeCollectionReadOnlyStream(TList list)
        {
            _list = list;
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _list.Length;

        public override long Position
        {
            get => _position;
            set
            {
                int intValue = checked((int) value);
                if (intValue < 0 || intValue > _list.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(Position));
                }
                _position = intValue;
            }
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (offset + count > buffer.Length)
            {
                throw new ArgumentException("Offset + count is greater than buffer length.");
            }
            
            int bytesAvailable = _list.Length - _position;
            if (bytesAvailable <= 0)
            {
                return 0;
            }

            int bytesCopied = Mathf.Min(count, bytesAvailable);
            unsafe
            {
                void* src = UnsafeUtility.AddressOf(ref _list.ElementAt(_position));
                fixed (byte* dest = buffer)
                {
                    UnsafeUtility.MemCpy(dest + offset, src, bytesCopied);
                }
            }
            _position += bytesCopied;
            return bytesCopied;
        }

        public override int ReadByte()
        {
            if (_position >= _list.Length)
            {
                return -1;
            }
            else
            {
                int value = _list[_position];
                _position++;
                return value;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPosition;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPosition = offset;
                    break;
                
                case SeekOrigin.Current:
                    newPosition = _position + offset;
                    break;
                
                case SeekOrigin.End:
                    newPosition = Length - offset;
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(origin));
            }
            if (newPosition < 0 || newPosition > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            _position = checked((int) newPosition);
            return newPosition;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void WriteByte(byte value)
        {
            throw new NotSupportedException();
        }
    }

    public class NativeCollectionStream<TList> : NativeCollectionReadOnlyStream<TList>
        where TList : INativeList<byte>
    {
        public NativeCollectionStream(TList list) : base(list) {}

        public override bool CanWrite => true;

        public override void WriteByte(byte value)
        {
            if (_position >= _list.Length)
            {
                _list.Length++;
            }
            _list[_position] = value;
            _position++;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (offset + count > buffer.Length)
            {
                throw new ArgumentException("Offset + count is greater than buffer length.");
            }

            if (_position + count > _list.Length)
            {
                _list.Length = _position + count;
            }

            unsafe
            {
                void* dest = UnsafeUtility.AddressOf(ref _list.ElementAt(_position));
                fixed (byte* src = buffer)
                {
                    UnsafeUtility.MemCpy(dest, src + offset, count);
                }
            }
            _position += count;
        }

        public override void SetLength(long value)
        {
            _list.Length = checked((int) value);
        }
    }

}
