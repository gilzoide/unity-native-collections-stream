using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeTextStream : NativeCollectionStream<NativeText>
    {
        public NativeTextStream(NativeText text) : base(text) {}
    }

    public class UnsafeTextStream : NativeCollectionStream<UnsafeText>
    {
        public UnsafeTextStream(UnsafeText text) : base(text) {}
    }

    public class FixedString32BytesStream : NativeCollectionStream<FixedString32Bytes>
    {
        public FixedString32BytesStream(FixedString32Bytes text) : base(text) {}
    }

    public class FixedString64BytesStream : NativeCollectionStream<FixedString64Bytes>
    {
        public FixedString64BytesStream(FixedString64Bytes text) : base(text) {}
    }

    public class FixedString128BytesStream : NativeCollectionStream<FixedString128Bytes>
    {
        public FixedString128BytesStream(FixedString128Bytes text) : base(text) {}
    }

    public class FixedString512BytesStream : NativeCollectionStream<FixedString512Bytes>
    {
        public FixedString512BytesStream(FixedString512Bytes text) : base(text) {}
    }

    public class FixedString4096BytesStream : NativeCollectionStream<FixedString4096Bytes>
    {
        public FixedString4096BytesStream(FixedString4096Bytes text) : base(text) {}
    }
}
