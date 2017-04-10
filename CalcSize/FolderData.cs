namespace CalcSize
{
    public class FolderData : PropChangeBase
    {
        private string folderName;
        public string FolderName
        {
            get { return folderName; }
            set
            {                
                folderName = value;
                OnPropertyChanged("FolderName");
                OnPropertyChanged("FullText");
            }
        }

        private long bytes;
        public long Bytes
        {
            get { return bytes; }
            set
            {                
                bytes = value;
                OnPropertyChanged("FullText");
                OnPropertyChanged("Bytes");
            }
        }

        public string FullText
        {
            get
            {
                return $"{folderName} {bytes}";
            }
        }

        public FolderData(string folder)
        {
            FolderName = folder;
        }

    }
}
