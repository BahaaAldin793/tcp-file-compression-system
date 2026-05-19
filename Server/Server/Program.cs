using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Server
{
    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread t = new Thread(() => HandleClient(client));
            t.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        try
        {
            NetworkStream stream = client.GetStream();

            // استقبل حجم الملف
            byte[] sizeBuffer = new byte[4];
            stream.Read(sizeBuffer, 0, 4);
            int fileSize = BitConverter.ToInt32(sizeBuffer, 0);
            Console.WriteLine($"Receiving file: {fileSize} bytes");

            // استقبل الملف
            byte[] fileBytes = new byte[fileSize];
            int totalRead = 0;
            while (totalRead < fileSize)
            {
                int read = stream.Read(fileBytes, totalRead, fileSize - totalRead);
                if (read == 0) break;
                totalRead += read;
            }

            // اضغط الملف
            byte[] compressedBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress))
                {
                    gzip.Write(fileBytes, 0, fileBytes.Length);
                }
                compressedBytes = ms.ToArray();
            }
            Console.WriteLine($"Compressed: {compressedBytes.Length} bytes");

            // ابعت حجم الملف المضغوط
            byte[] compressedSize = BitConverter.GetBytes(compressedBytes.Length);
            stream.Write(compressedSize, 0, 4);

            // ابعت الملف المضغوط
            stream.Write(compressedBytes, 0, compressedBytes.Length);
            Console.WriteLine("Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Client error: " + ex.Message);
        }
        finally
        {
            client.Close();
        }
    }
}