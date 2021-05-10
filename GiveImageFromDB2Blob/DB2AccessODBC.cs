
namespace Common
{
    public class DB2AccessODBC
    {
        private System.Data.Odbc.OdbcConnection _odbcConnection = null;

        private string _connectingString = null;

        public string ConnectingString
        {
            get { return _connectingString; }
            set { _connectingString = value; }
        }

        public DB2AccessODBC()
        {
        }

        public void Open()
        {
            try
            {
                _odbcConnection = new System.Data.Odbc.OdbcConnection();

                ///ESTA STRING CONN TEVE SUCESSO
                string conn = "Driver={IBM DB2 ODBC DRIVER};Hostname=xpto.dev.com;Port=3358;Database=myDB;Protocol=TCPIP;UID=myUser;PWD=myPass;";
                _odbcConnection.ConnectionString = conn;
                _odbcConnection.Open();
            }
            catch (System.Exception ex)
            {
                _odbcConnection = null;
                throw ex;
            }

        }

        public void Close()
        {
            if (_odbcConnection == null)
                return;

            try
            {
                _odbcConnection.Close();
                _odbcConnection.Dispose();
                _odbcConnection = null;
            }
            catch (System.Exception ex)
            {
                _odbcConnection = null;
                throw ex;
            }
        }

        public string[] GetAllImages(string imageID)
        {
            string[] retImagesFullName = new string[3] { "", "", "" };

            if (_odbcConnection == null)
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

            if (_odbcConnection == null)
                return retImageFullName;

            //ODBC Access
            System.Data.Odbc.OdbcCommand odbcCommand = null;
            System.Data.Odbc.OdbcDataReader odbcRead = null;

            try
            {
                odbcCommand = new System.Data.Odbc.OdbcCommand();

                odbcCommand.CommandText = "SELECT " + column + " FROM MY_DB.MY_TABLE_IMAGENS WHERE IMAGE_ID = '" + imageID + "'";

                odbcCommand.Connection = _odbcConnection;

                odbcRead = odbcCommand.ExecuteReader();  //System.Data.CommandBehavior.SequentialAccess
                //byte[] _buf = (byte[]) odbcCommand.ExecuteScalar();

                //if (!odbcRead.Read())
                //    return retImageFullName; //not found

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
                retval = odbcRead.GetBytes(0, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    //Write the buffer. (convert byte to char)
                    for (int i = 0; i < retval; i++)
                        sb.Append(System.Convert.ToChar(outByte[i]));

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = odbcRead.GetBytes(0, startIndex, outByte, 0, bufferSize);
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
                odbcRead.Close();
                odbcCommand.Dispose();
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
