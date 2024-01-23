using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeListStream : NativeCollectionStream<NativeList<byte>>
    {
        public NativeListStream(NativeList<byte> list) : base(list) {}
    }

    public class UnsafeListStream : NativeCollectionReadOnlyStream<UnsafeList<byte>>
    {
        public UnsafeListStream(UnsafeList<byte> list) : base(list) {}
    }

    public class FixedList32BytesStream : NativeCollectionReadOnlyStream<FixedList32Bytes<byte>>
    {
        public FixedList32BytesStream(FixedList32Bytes<byte> list) : base(list) {}
    }

    public class FixedList64BytesStream : NativeCollectionReadOnlyStream<FixedList64Bytes<byte>>
    {
        public FixedList64BytesStream(FixedList64Bytes<byte> list) : base(list) {}
    }

    public class FixedList128BytesStream : NativeCollectionReadOnlyStream<FixedList128Bytes<byte>>
    {
        public FixedList128BytesStream(FixedList128Bytes<byte> list) : base(list) {}
    }

    public class FixedList512BytesStream : NativeCollectionReadOnlyStream<FixedList512Bytes<byte>>
    {
        public FixedList512BytesStream(FixedList512Bytes<byte> list) : base(list) {}
    }

    public class FixedList4096BytesStream : NativeCollectionReadOnlyStream<FixedList4096Bytes<byte>>
    {
        public FixedList4096BytesStream(FixedList4096Bytes<byte> list) : base(list) {}
    }
}
