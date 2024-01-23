using System.IO;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeTextWriter : StreamWriter
    {
        public NativeTextWriter(NativeText text) : this(text, 1024) {}
        public NativeTextWriter(NativeText text, int bufferSize) : base(new NativeTextStream(text), Encoding.UTF8, bufferSize) {}
    }

    public class UnsafeTextWriter : StreamWriter
    {
        public UnsafeTextWriter(UnsafeText text) : this(text, 1024) {}
        public UnsafeTextWriter(UnsafeText text, int bufferSize) : base(new UnsafeTextStream(text), Encoding.UTF8, bufferSize) {}
    }

    public class FixedString32BytesWriter : StreamWriter
    {
        public FixedString32BytesWriter(FixedString32Bytes text) : this(text, 32) {}
        public FixedString32BytesWriter(FixedString32Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString32Bytes>(text), Encoding.UTF8, bufferSize) {}
    }

    public class FixedString64BytesWriter : StreamWriter
    {
        public FixedString64BytesWriter(FixedString64Bytes text) : this(text, 64) {}
        public FixedString64BytesWriter(FixedString64Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString64Bytes>(text), Encoding.UTF8, bufferSize) {}
    }

    public class FixedString128BytesWriter : StreamWriter
    {
        public FixedString128BytesWriter(FixedString128Bytes text) : this(text, 128) {}
        public FixedString128BytesWriter(FixedString128Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString128Bytes>(text), Encoding.UTF8, bufferSize) {}
    }

    public class FixedString512BytesWriter : StreamWriter
    {
        public FixedString512BytesWriter(FixedString512Bytes text) : this(text, 512) {}
        public FixedString512BytesWriter(FixedString512Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString512Bytes>(text), Encoding.UTF8, bufferSize) {}
    }

    public class FixedString4096BytesWriter : StreamWriter
    {
        public FixedString4096BytesWriter(FixedString4096Bytes text) : this(text, 1024) {}
        public FixedString4096BytesWriter(FixedString4096Bytes text, int bufferSize) : base(new NativeCollectionStream<FixedString4096Bytes>(text), Encoding.UTF8, bufferSize) {}
    }
}
