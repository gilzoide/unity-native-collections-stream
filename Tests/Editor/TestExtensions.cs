using Unity.Collections;
using UnityEngine;

namespace Gilzoide.NativeCollectionsStream.Tests.Editor
{
    public static class TestExtensions
    {
        public static void Fill<TList>(this TList list)
            where TList : struct, INativeList<byte>
        {
            list.Fill(list.Capacity);
        }

        public static void Fill<TList>(this TList list, int newLength)
            where TList : struct, INativeList<byte>
        {
            list.Length = newLength;
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = (byte) Random.Range(0, byte.MaxValue);
            }
        }
    }
}
