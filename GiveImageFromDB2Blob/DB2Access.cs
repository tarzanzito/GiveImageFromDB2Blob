
namespace Common
{
    public class DB2Access
    {
        //add ref -> IBM.Data.DB2.dll ->  C:\Applics\IBM\SQLLIB\BIN\netf11
        private IBM.Data.DB2.DB2Connection _DB2Conn = null;

        private string _connectingString = null;

        public string ConnectingString
        {
            get { return _connectingString; }
            set { _connectingString = value; }
        }

        public DB2Access()
        {
        }

        public void Open()
        {
            try
            {
                _DB2Conn = new IBM.Data.DB2.DB2Connection();
                _DB2Conn.ConnectionString = _connectingString;
                _DB2Conn.Open();
            }
            catch (System.Exception ex)
            {
                _DB2Conn = null;
                throw ex;
            }

        }

        public void Close()
        {
            if (_DB2Conn == null)
                return;

            try
            {
                _DB2Conn.Close();
                _DB2Conn.Dispose();
                _DB2Conn = null;
            }
            catch (System.Exception ex)
            {
                _DB2Conn = null;
                throw ex;
            }
        }

        public string[] GetAllImages(string imageID)
        {
            string[] retImagesFullName = new string[3] { "", "", "" };

            if (_DB2Conn == null)
                return retImagesFullName;

            string[] imagesName = new string[3] { "Image1.jpg", "Image2.jpg", "Image3.tiff" };
            string[] sqlColumns = new string[3] { "IMAGEM1", "IMAGEM2", "IMAGEM3" };
            string myDocFolder = null;

            //Delete old files
            try
            {
                myDocFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonPictures) + "\\";

                System.IO.File.Delete(myDocFolder + imagesName[0]);
                System.IO.File.Delete(myDocFolder + imagesName[1]);
                System.IO.File.Delete(myDocFolder + imagesName[2]);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            try
            {
                retImagesFullName[0] = GetColumnImage(imageID, sqlColumns[0], imagesName[0]);
                retImagesFullName[1] = GetColumnImage(imageID, sqlColumns[1], imagesName[1]);
                retImagesFullName[2] = GetColumnImage(imageID, sqlColumns[2], imagesName[2]);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return retImagesFullName;
        }


        private string GetColumnImage(string imageID, string column, string fileName)
        {
            string retImageFullName = "";

            if (_DB2Conn == null)
                return retImageFullName;

            //DB2 Access
            IBM.Data.DB2.DB2Command DB2cmd = null;
            IBM.Data.DB2.DB2DataReader DB2read = null;

            try
            {
                DB2cmd = new IBM.Data.DB2.DB2Command();

                DB2cmd.CommandText = "SELECT " + column + " FROM MY_DB.MY_TABLE_IMAGENS WHERE IMAGE_ID = '" + imageID + "'";

                DB2cmd.Connection = _DB2Conn;

                DB2read = DB2cmd.ExecuteReader(); //System.Data.CommandBehavior.SequentialAccess);

                if (!DB2read.Read())
                    return retImageFullName; //not found

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            //Read BLOB
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            int bufferSize = 100;
            byte[] outByte = new byte[bufferSize];
            long retval;
            long startIndex = 0;

            try
            {
                // Read bytes into outByte[] and retain the number of bytes returned.
                retval = DB2read.GetBytes(0, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    //Write the buffer. (convert byte to char)
                    for (int i = 0; i < retval; i++)
                        sb.Append(System.Convert.ToChar(outByte[i]));

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = DB2read.GetBytes(0, startIndex, outByte, 0, bufferSize);
                }

                // Write the remaining buffer. (convert byte to char)
                for (int i = 0; i < retval; i++)
                    sb.Append(System.Convert.ToChar(outByte[i]));

            }
            catch
            {
            }

            //Close DB2 reader
            try
            {
                DB2read.Close();
                DB2cmd.Dispose();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


            //Create file
            try
            {
                if (sb.Length > 0)
                {
                    string myDocFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonPictures) + "\\";

                    string text = sb.ToString();
                    byte[] base64EncodedBytes = System.Convert.FromBase64String(text);

                    System.IO.File.WriteAllBytes(myDocFolder + fileName, base64EncodedBytes);
                    retImageFullName = myDocFolder + fileName;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return retImageFullName;
        }
    }
}
