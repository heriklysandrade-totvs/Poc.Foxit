using foxit.common.fxcrt;
using System.Runtime.InteropServices;

namespace Poc.Foxit.CallBacks
{
    public class FileWriterCustom : FileWriterCallback
    {
        private readonly MemoryStream fileMemoryStream = new MemoryStream();

        public FileWriterCustom()
        {

        }

        public override long GetSize()
        {
            return this.fileMemoryStream.Length;
        }

        public override bool WriteBlock(IntPtr pData, long offset, uint size)
        {
            byte[] ys = new byte[size];
            Marshal.Copy(pData, ys, 0, (int)size);
            fileMemoryStream.Write(ys, 0, (int)size);
            return true;
        }

        public override bool Flush()
        {
            fileMemoryStream.Flush();
            return true;
        }

        public override void Release()
        {
            fileMemoryStream.Dispose();
        }

        public byte[] GetFileBytes()
        {
            return fileMemoryStream.ToArray();
        }
    }
}
