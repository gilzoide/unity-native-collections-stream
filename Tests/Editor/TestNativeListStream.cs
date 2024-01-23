using NUnit.Framework;
using Unity.Collections;
using UnityEngine;

namespace Gilzoide.NativeCollectionsStream.Tests.Editor
{
    public class TestNativeListStream
    {
        [SetUp]
        public void SetUp()
        {
            Random.InitState(42);
        }

        public static int[] ListSizes = { 0, 1, 10, 100, 1000, 10000 };

        #region ReadByte
        
        [Test, TestCaseSource(nameof(ListSizes))]
        public void NativeListStream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                list.Fill(listSize);
                NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
            }
        }

        [Test, TestCase(0), TestCase(1), TestCase(30)]
        public void FixedList32Stream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList32Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(62)]
        public void FixedList64Stream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList64Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(126)]
        public void FixedList128Stream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList128Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(510)]
        public void FixedList512Stream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList512Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(4094)]
        public void FixedList4096Stream_ReadByte_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList4096Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_ReadByte_ShouldReturnTheSameBytes(list);
        }

        private static void NativeListStream_ReadByte_ShouldReturnTheSameBytes<TList>(TList list)
            where TList : INativeList<byte>
        {
            list.Length = list.Capacity;
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (byte) Random.Range(0, byte.MaxValue);
            }

            using (var stream = new NativeCollectionStream<TList>(list))
            {
                for (int i = 0; i < list.Length; i++)
                {
                    Assert.That(stream.ReadByte(), Is.EqualTo(list[i]));
                }
                Assert.That(stream.ReadByte(), Is.LessThan(0));
                Assert.That(stream.ReadByte(), Is.LessThan(0));
                Assert.That(stream.ReadByte(), Is.LessThan(0));
            }
        }

        #endregion

        #region Read
        
        [Test, TestCaseSource(nameof(ListSizes))]
        public void NativeListStream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                list.Fill(listSize);
                NativeListStream_Read_ShouldReturnTheSameBytes(list);
            }
        }

        [Test, TestCase(0), TestCase(1), TestCase(30)]
        public void FixedList32Stream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList32Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_Read_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(62)]
        public void FixedList64Stream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList64Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_Read_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(126)]
        public void FixedList128Stream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList128Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_Read_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(510)]
        public void FixedList512Stream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList512Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_Read_ShouldReturnTheSameBytes(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(4094)]
        public void FixedList4096Stream_Read_ShouldReturnTheSameBytes(int listSize)
        {
            var list = new FixedList4096Bytes<byte>();
            list.Fill(listSize);
            NativeListStream_Read_ShouldReturnTheSameBytes(list);
        }

        private static void NativeListStream_Read_ShouldReturnTheSameBytes<TList>(TList list)
            where TList : INativeList<byte>
        {
            list.Length = list.Capacity;
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (byte) Random.Range(0, byte.MaxValue);
            }

            var buffer = new byte[128];

            using (var stream = new NativeCollectionStream<TList>(list))
            {
                int listIndex = 0;
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    Assert.That(bytesRead, Is.LessThanOrEqualTo(buffer.Length));
                    if (bytesRead <= 0)
                    {
                        break;
                    }
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Assert.That(listIndex < list.Length);
                        Assert.That(buffer[i], Is.EqualTo(list[listIndex]));
                        listIndex++;
                    }
                }
                Assert.That(stream.Read(buffer, 0, buffer.Length), Is.EqualTo(0));
                Assert.That(stream.Read(buffer, 0, buffer.Length), Is.EqualTo(0));
                Assert.That(stream.Read(buffer, 0, buffer.Length), Is.EqualTo(0));
            }
        }

        #endregion
    }
}
