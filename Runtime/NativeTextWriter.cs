using System.IO;
using System.Text;
using Unity.Collections;

namespace Gilzoide.NativeCollectionsStream
{
    public class NativeTextWriter : StreamWriter
    {
        public NativeTextWriter(NativeText text) : this(text, 1024) {}
        public NativeTextWriter(NativeText text, int bufferSize) : base(new NativeTextStream(text), Encoding.UTF8, bufferSize) {}
    }
}
