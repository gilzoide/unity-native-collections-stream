using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeListStream : NativeCollectionStream<NativeList<byte>>
    {
        public NativeListStream(NativeList<byte> list) : base(list) {}
    }

    public class UnsafeListStream : NativeCollectionStream<UnsafeList<byte>>
    {
        public UnsafeListStream(UnsafeList<byte> list) : base(list) {}
    }

    public class FixedList32BytesStream : NativeCollectionStream<FixedList32Bytes<byte>>
    {
        public FixedList32BytesStream(FixedList32Bytes<byte> list) : base(list) {}
    }

    public class FixedList64BytesStream : NativeCollectionStream<FixedList64Bytes<byte>>
    {
        public FixedList64BytesStream(FixedList64Bytes<byte> list) : base(list) {}
    }

    public class FixedList128BytesStream : NativeCollectionStream<FixedList128Bytes<byte>>
    {
        public FixedList128BytesStream(FixedList128Bytes<byte> list) : base(list) {}
    }

    public class FixedList512BytesStream : NativeCollectionStream<FixedList512Bytes<byte>>
    {
        public FixedList512BytesStream(FixedList512Bytes<byte> list) : base(list) {}
    }

    public class FixedList4096BytesStream : NativeCollectionStream<FixedList4096Bytes<byte>>
    {
        public FixedList4096BytesStream(FixedList4096Bytes<byte> list) : base(list) {}
    }
}
