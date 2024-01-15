﻿using foxit.common.fxcrt;
using System.Runtime.InteropServices;

namespace Poc.Foxit.CallBacks
{
    public class FileReaderCustom : FileReaderCallback
    {
        private MemoryStream? fileMemoryStream;
        private readonly long offset_ = 0;

        public FileReaderCustom(long offset)
        {
            offset_ = offset;
        }

        public bool LoadFile(byte[] fileBytes)
        {
            fileMemoryStream = new MemoryStream(fileBytes);
            return true;
        }

        public override long GetSize()
        {
            return offset_;
        }

        public override bool ReadBlock(IntPtr buffer, long offset, uint size)
        {
            int read_size;
            fileMemoryStream.Seek(offset, SeekOrigin.Begin);
            byte[] array = new byte[size + 1];
            read_size = fileMemoryStream.Read(array, 0, (int)size);
            Marshal.Copy(array, 0, buffer, (int)size);
            return read_size == size;
        }

        public override void Release()
        {
            fileMemoryStream.Close();
        }
    }
}