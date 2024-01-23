using System.Collections.Generic;
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
        public void NativeListStream_ReadByte(int listSize)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                list.Fill(listSize);
                TestReadByte(list);
            }
        }

        [Test, TestCase(0), TestCase(1), TestCase(30)]
        public void FixedList32Stream_ReadByte(int listSize)
        {
            var list = new FixedList32Bytes<byte>();
            list.Fill(listSize);
            TestReadByte(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(62)]
        public void FixedList64Stream_ReadByte(int listSize)
        {
            var list = new FixedList64Bytes<byte>();
            list.Fill(listSize);
            TestReadByte(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(126)]
        public void FixedList128Stream_ReadByte(int listSize)
        {
            var list = new FixedList128Bytes<byte>();
            list.Fill(listSize);
            TestReadByte(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(510)]
        public void FixedList512Stream_ReadByte(int listSize)
        {
            var list = new FixedList512Bytes<byte>();
            list.Fill(listSize);
            TestReadByte(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(4094)]
        public void FixedList4096Stream_ReadByte(int listSize)
        {
            var list = new FixedList4096Bytes<byte>();
            list.Fill(listSize);
            TestReadByte(list);
        }

        private static void TestReadByte<TList>(TList list)
            where TList : INativeList<byte>
        {
            list.Length = list.Capacity;
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (byte) Random.Range(0, byte.MaxValue);
            }

            using (var stream = new NativeCollectionReadOnlyStream<TList>(list))
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
        public void NativeListStream_Read(int listSize)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                list.Fill(listSize);
                TestRead(list);
            }
        }

        [Test, TestCase(0), TestCase(1), TestCase(30)]
        public void FixedList32Stream_Read(int listSize)
        {
            var list = new FixedList32Bytes<byte>();
            list.Fill(listSize);
            TestRead(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(62)]
        public void FixedList64Stream_Read(int listSize)
        {
            var list = new FixedList64Bytes<byte>();
            list.Fill(listSize);
            TestRead(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(126)]
        public void FixedList128Stream_Read(int listSize)
        {
            var list = new FixedList128Bytes<byte>();
            list.Fill(listSize);
            TestRead(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(510)]
        public void FixedList512Stream_Read(int listSize)
        {
            var list = new FixedList512Bytes<byte>();
            list.Fill(listSize);
            TestRead(list);
        }

        [Test, TestCase(0), TestCase(1), TestCase(4094)]
        public void FixedList4096Stream_Read(int listSize)
        {
            var list = new FixedList4096Bytes<byte>();
            list.Fill(listSize);
            TestRead(list);
        }

        private static void TestRead<TList>(TList list)
            where TList : INativeList<byte>
        {
            using (var stream = new NativeCollectionReadOnlyStream<TList>(list))
            {
                var buffer = new byte[128];
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
    
        #region WriteByte

        [Test, TestCaseSource(nameof(ListSizes))]
        public void NativeListStream_WriteByte(int byteCount)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                TestWriteByte(list, byteCount);
            }
        }

        private static void TestWriteByte<TList>(TList list, int byteCount)
            where TList : INativeList<byte>
        {
            list.Clear();
            var managedList = new List<byte>();
            using (var stream = new NativeCollectionStream<TList>(list))
            {
                for (int i = 0; i < byteCount; i++)
                {
                    var value = (byte) Random.Range(0, byte.MaxValue);
                    managedList.Add(value);
                    stream.WriteByte(value);
                }
            }

            Assert.That(list.Length, Is.EqualTo(byteCount));
            for (int i = 0; i < byteCount; i++)
            {
                Assert.That(list[i], Is.EqualTo(managedList[i]));
            }
        }

        #endregion
    
        #region Write

        [Test, TestCaseSource(nameof(ListSizes))]
        public void NativeListStream_Write(int byteCount)
        {
            using (var list = new NativeList<byte>(Allocator.Temp))
            {
                TestWrite(list, byteCount);
            }
        }

        private static void TestWrite<TList>(TList list, int byteCount)
            where TList : INativeList<byte>
        {
            list.Clear();
            
            var array = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                array[i] = (byte) Random.Range(0, byte.MaxValue);
            }
            using (var stream = new NativeCollectionStream<TList>(list))
            {
                const int blockSize = 128;
                for (int i = 0; i < byteCount; i += blockSize)
                {
                    int count = Mathf.Min(byteCount - i, blockSize);
                    stream.Write(array, i, count);
                }
            }

            Assert.That(list.Length, Is.EqualTo(byteCount));
            for (int i = 0; i < byteCount; i++)
            {
                Assert.That(list[i], Is.EqualTo(array[i]));
            }
        }

        #endregion

    }
}
