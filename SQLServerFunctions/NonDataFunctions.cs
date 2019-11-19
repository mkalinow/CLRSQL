using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace SQLServerFunctions
{
    public static class NonDataFunctions
    {
        //This method will take an input string and hash it according to MD5 hashing
        [SqlFunction(DataAccess =DataAccessKind.None,IsDeterministic =true)]
        public static SqlString HashAStringMD5(string InputString)
        {
            //SqlString results = new SqlString();
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(InputString));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            //results = new SqlChars(sBuilder.ToString());
            SqlString results = new SqlString(sBuilder.ToString());
            //set the out variable to the hashed string
            return results;
        }
    }
}
