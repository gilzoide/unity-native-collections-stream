using System.IO;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeTextReader : StreamReader
    {
        public NativeTextReader(NativeText text) : this(text, 1024) {}
        public NativeTextReader(NativeText text, int bufferSize) : base(new NativeTextStream(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class UnsafeTextReader : StreamReader
    {
        public UnsafeTextReader(UnsafeText text) : this(text, 1024) {}
        public UnsafeTextReader(UnsafeText text, int bufferSize) : base(new UnsafeTextStream(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class FixedString32BytesReader : StreamReader
    {
        public FixedString32BytesReader(FixedString32Bytes text) : this(text, 32) {}
        public FixedString32BytesReader(FixedString32Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString32Bytes>(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class FixedString64BytesReader : StreamReader
    {
        public FixedString64BytesReader(FixedString64Bytes text) : this(text, 64) {}
        public FixedString64BytesReader(FixedString64Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString64Bytes>(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class FixedString128BytesReader : StreamReader
    {
        public FixedString128BytesReader(FixedString128Bytes text) : this(text, 128) {}
        public FixedString128BytesReader(FixedString128Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString128Bytes>(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class FixedString512BytesReader : StreamReader
    {
        public FixedString512BytesReader(FixedString512Bytes text) : this(text, 512) {}
        public FixedString512BytesReader(FixedString512Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString512Bytes>(text), Encoding.UTF8, false, bufferSize) {}
    }

    public class FixedString4096BytesReader : StreamReader
    {
        public FixedString4096BytesReader(FixedString4096Bytes text) : this(text, 1024) {}
        public FixedString4096BytesReader(FixedString4096Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString4096Bytes>(text), Encoding.UTF8, false, bufferSize) {}
    }
}
