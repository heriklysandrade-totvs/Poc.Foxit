﻿using foxit.common;
using foxit.pdf;
using Microsoft.AspNetCore.Mvc;
using Poc.Foxit.Api.Responses;
using Poc.Foxit.CallBacks;
using Poc.Foxit.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using static foxit.pdf.PDFDoc;

namespace Poc.Foxit.Controllers
{
    [Route("v1/foxit")]
    [ApiController]
    [ApiVersion("1.0")]
    public class FoxitController : ControllerBase
    {
        ////KEYS WINDOWS
        //private readonly string sn = "kW666IJog823emP2MypGbWtO+vNIxGU/GwukbDTQ8U8LCOEhGkAozw==";
        //private readonly string key = "8f3gFcGNvRsN+jePnKBLSM96XbbRwDckeQE7HZAKN4nNZ9WdRPV/YRXMa3dGG2yFpMgl9kp8uJGHtemhuoiikvEMeenPqSw1LjUyu6Ug8gEgb+pirHMB8Co2VjcQdNP4aMt4d4JyqKxFDarQZCSwQnHa0/CmhNZ82JzpBdKLV35c2MwFRE5FOiyHdnSzvDsODGzBYvQDC+1ShiJIwBvdV7Gw2zdVK2qhZ/k0QLg+IhMSW71taxoz5sCI4QizpTv3c6Iu1YLv0OuS2hEt29y6ejjgr0JKVt/DIVyLyRWtaKRbE7/jGHbVIcqZNdkzpfmO9XWCMJHTCJzF8eDiQF1xsNyMK/uNMDEzPDH/gwB7JSAbQr02OIapyu8LKbZflhuUv+Su6TLpAzM89U9KZABXTKjNSLtRdr22di3cWgLvlvA9hQ8jVhDBKLyjn8oThLz2sPtoEpJNzXr/1EaBLsQymVxkLixWJl8LUqg8CgaF4YJGk5wTjmemqPOLO/dLkjrosmZFKCnX49E5Jg5kV8T1pXyUdMhH6IAqCuC/74wvI0nMbjetxJv1qPnxD93SWDE1NNTu5aYxbhHuexbDutwHHpAWln+ZZPFt34otxtydaP6xchsRG/s5ppfjxzDit+SA/+jQWkOwNQRH9WMa7SEEAqXSc+BrpwqVN5QyCHAEqXugGrEl6FtPqns6bZGTpyWsELbTNZpsZrvH4X5G+W7c4AC4tyUnGpvDUZGdzfNAQBHeDSTXVN3FKFud8AYZ6YSWh1gtNHf+YV9dfWxGY7CG+1pBL9A52IhlxcoMWuZymO5QeEhHyyLVju4407MUGuB9nV98Mc1+FPVMAReyQPEF9wfL5YEydF/M70qoqacxAJgRAO4qSTtMQQNEbep3AjpzEyQ6Lktn7WwHBy/r3NTSuOO5GWX2uDUwarpewy7r+h/UDXEP3X7iXnErFc5wFqHml/1YCMXzHLfoo6O6e3jhAKLMQKAYuWm0QFl44ss7Ogc+XUSUHpL6EwugBxY/bYtYlb2JO4kbmqQpHJHTOie7Fbk3h3jTyTl6e7hzCXGXwwlklcxp53Vr/vkW4eGEB3BYIkcNCU/KEY2AA4PLmsOJ+fM7xYvdZI64edsXDAdq9/891EflX7XWrNYCtfElaS84c/SGFBNbBQS6Fohg+dcv1+OsCBV2RvNdZHVCoQ/dmOk/oVolDimwJj949jm7lFxuxnXgcFWOrbD8PgBSrRko90EZ068lM4QbtSIELl1aVazpL/Uf7rPwJ7FT2TP0U+pO+pNPbrI1a+aabN9y48uOcrLiA+ELZFl6RNJJ4I3vdN2ztc4n+f1yrGrnhhc0UBXSgZ7N5l4JisjBW0kfIq94PVyo5aWagiX6641M1Q==";

        ////KEYS LINUX
        private readonly string sn = "Yuxay2IBiZFQdnbPWWm6PzjrzHMAxgU/0bvdTs2ax0gGAp21btiJXQ==";
        private readonly string key = "8f3gFUOMvWsN+XetmKjesLrtEITlig6PK1SEzio0De6nF5lhXOGH5OPngzhkBbuEpb4RGJAqjEuPZZHbP8TZSd+U31C14rAdz8K5nEB7BV8WlFyRi+GM+IBCm8kBOThQCvXU+UZcASoFhq0TZwmSGrHGoft7M3Oi9RASaeS48TlzuxDxgUFR2fWGcHRzuOIx1XQ8FvLjJ4c3VoPq0IHJ61XE0Ad/G8Xbdr1apVAqMXzDm3lY9gf8+/Ffos3udWH/Qqwm09FtXluLjEHYf9luWjJ8fYsYcdgwF5dKlQpCC/rntDwt9PZVxC9ikc5WiZAgrlUW0GPWFRajfel7a4WRIdNXoRLLYSascBlyhrIf2G7h3OKQsLHIO4/ITYOasnUdHEHxaB5sHhI9B0g9QPMh8Zf9R5xVwu3WrG9eRlFo5cNmfJZtakBbo4tWKWGp2fENX/ssBHRNyq27bWgK5B4HFRePLToFy/GQvclAV57D3I2UxlZRSm31qWhcg85e3dfwMHr9+70wbS+RfBHr9EX0RWiedUhG4vDGCeGTKiw1jJ5iWWka+NH1SCyuzPMIDbmg3G+GB0iqHiEScFjCutwGHpGo+ioe5zRo9GqMextorTVbsE16+Eof1kKF+dzDt0SoE6nR3EMwNeS1xW8a7WG0iJX1Ew1mmSEBX5d5fpPxFjjRtwPJX47gBlwjQGv2eCXjOgVk1r1jZqkoga8+8M71co7dgzfN92LAGDexuCVOPCLUO7oGt5jgGy9VG9qQVOVHW1Qpt8RCtZACa5dqTVg+vkv6M+Cih8+/bE3u+x3nMLJMpMUXXhUgC5/zskXYCl/Zb3Nq9cM0wHafRybfYoQ8zhLTqeqzYGOB5qrxrYxlOaoWrmkIsH+Pllnp04r32rGkKPcd5rkmuubueByVSgh4gw9IwqKdqOJCbkTF5oTCbZ5cbV66VbSs3PY7CZwdiicX7wtvvR2EE9Ijmut9WjJdoilqYl4WC4RA/Zz52XoHhra/wyScoDV/hKXFtwbL2Vs5aJdDnrleBFp+sQCOajmU1i2lwKQdi2V+IdlJ3VsjxqZtpd/3LAvfXQ8P0yKM09J9gCdOiIcyv05Lg28yjjV1ynpQ0VlJTW5rxqQcTZr04S4lwl2qWc5CV2v0Hac1YcmSvv+uFOabHdi/FDQi1gJYDOCw+6xgVke1IuN7b7eC2S9fq8Z6dbxDPvQxTcFP9jkgOg1EgPhnOIS4ZLfv/78N8iGZB2nuoH/od/QP65zqfrrUqlt73iMSMwdef8tV5hBIxBPNb7J1a+aWbN8nVqFPIxiXNC61Z+dYbSb8ayc8ZrRszOo5svAwozW2GuQf5LvNo7rUbXuw2aJu+FB9cnKx3Djk4OnsiUTCjEFMZQ==";

        public FoxitController()
        {
            try
            {
                Console.WriteLine("**LOCAL CONSOLE** Initializing foxit lib.");

                ErrorCode error_code = Library.Initialize(sn, key);
                if (error_code != ErrorCode.e_ErrSuccess)
                {
                    Console.WriteLine($"**LOCAL CONSOLE** Initialize fail. Error code: {error_code}");
                }

                Console.WriteLine("**LOCAL CONSOLE** Foxit Lib succesefully initialized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"**LOCAL CONSOLE** Unhandled exception while initializing Foxit lib: {ex.Message}");
            }
        }

        [SwaggerOperation("Open and returns a single file.")]
        [HttpPost("open")]
        public IActionResult OpenFile(IFormFile formFile)
        {
            byte[] byte_buffer = formFile.GetBytesFromFormFile();
            IntPtr buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(byte_buffer.Length);

            try
            {
                System.Runtime.InteropServices.Marshal.Copy(byte_buffer, 0, buffer, byte_buffer.Length);
                using var doc = new PDFDoc(buffer, (uint)byte_buffer.Length);
                doc.Load(null);

                var fileWriter = new FileWriterCustom();
                doc.StartSaveAs(fileWriter, (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal, null);
                var result = fileWriter.GetFileBytes();
                return Ok(new OkResponse(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
            }
        }

        [SwaggerOperation("Merge various files in a foreach loop.")]
        [HttpPost("merge-add-pages")]
        public IActionResult MergeFilesAddPage(IFormFileCollection files, string fileName)
        {
            var finalDoc = new PDFDoc();
            finalDoc.Load(null);

            foreach (var file in files)
            {
                byte[] byte_buffer = file.GetBytesFromFormFile();
                IntPtr buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(byte_buffer.Length);

                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(byte_buffer, 0, buffer, byte_buffer.Length);
                    using var doc = new PDFDoc(buffer, (uint)byte_buffer.Length);
                    doc.Load(null);
                    var import_ranges = new foxit.common.Range(0, doc.GetPageCount() - 1, foxit.common.Range.Filter.e_All);
                    var destIndex = finalDoc.GetPageCount();
                    var progress = finalDoc.StartImportPages(destIndex, doc, (int)ImportPageFlags.e_ImportFlagNormal, "teste", import_ranges, null);

                    Progressive.State progress_state = Progressive.State.e_ToBeContinued;
                    while (Progressive.State.e_ToBeContinued == progress_state)
                    {
                        progress_state = progress.Continue();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
                    byte_buffer = null;
                }
            }

            var finalDocFileWriter = new FileWriterCustom();
            finalDoc.StartSaveAs(finalDocFileWriter, (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal, null);

            var result = finalDocFileWriter.GetFileBytes();

            finalDoc.Dispose();
            return Ok(new OkResponse(result));
        }

        [SwaggerOperation("Open a file and add a custom header.")]
        [HttpPost("manifest")]
        public IActionResult ManifestFile(IFormFile formFile, string headerText)
        {
            byte[] byte_buffer = formFile.GetBytesFromFormFile();
            IntPtr buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(byte_buffer.Length);

            try
            {
                System.Runtime.InteropServices.Marshal.Copy(byte_buffer, 0, buffer, byte_buffer.Length);
                using var doc = new PDFDoc(buffer, (uint)byte_buffer.Length);
                doc.Load(null);
                FillHashs(doc, headerText);

                var fileWriter = new FileWriterCustom();
                doc.StartSaveAs(fileWriter, (int)PDFDoc.SaveFlags.e_SaveFlagNoOriginal, null);
                var result = fileWriter.GetFileBytes();
                return Ok(new OkResponse(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
            }
        }

        private static void FillHashs(PDFDoc doc, string headerText)
        {
            // Prepare header.
            var header = new HeaderFooter
            {
                font = new Font("Simsun", (int)Font.Styles.e_StylesSmallCap, Font.Charset.e_CharsetGB2312, 0),
                content = new HeaderFooterContent(headerText, null, null, null, null, null),
                text_size = 12.0f
            };
            doc.AddHeaderFooter(header);
        }
    }
}