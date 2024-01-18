namespace Poc.Foxit.Api.Requests
{
    public class BasicResquest
    {
        public BasicResquest()
        {

        }

        public BasicResquest(IFormFileCollection files, string fileName, string headerText)
        {
            Files = files;
            FileName = fileName;
            HeaderText = headerText;
        }

        public IFormFileCollection Files { get; set; }
        public string FileName { get; set; }
        public string HeaderText { get; set; }
    }
}
