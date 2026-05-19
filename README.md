# 🗜️ TCP File Compression System

A client-server application that compresses files over a TCP connection. The server receives files, compresses them using GZip, and sends them back. Built with C# and .NET.

---

## 📁 Project Structure

```
TCPCompressionSystem/
├── CompressionServer/        # Console App - Multi-threaded server
│   └── Program.cs
└── CompressionClient/        # Windows Forms App - UI client
    ├── Form1.cs
    └── Form1.Designer.cs
```

---

## ⚙️ How It Works

```
Client                          Server
  |                               |
  |------ fileSize (4 bytes) ---->|
  |------ file bytes ------------>|
  |                               |  (compresses with GZip)
  |<----- compressedSize (4 bytes)|
  |<----- compressed bytes -------|
  |                               |
       saves file as .gz
```

1. Client connects to the server
2. Client sends file size (4 bytes) then the file bytes
3. Server compresses the file in memory using `GZipStream`
4. Server sends compressed size (4 bytes) then the compressed file
5. Client saves the result as `filename.gz`

---

## 🖥️ Server (Console App)

**Features:**
- Listens on port `5000`
- Multi-threaded: each client gets its own `Thread`
- Handles errors per client without crashing the server

**Key classes used:**
| Class | Purpose |
|---|---|
| `TcpListener` | Accepts incoming connections |
| `Thread` | Handles each client independently |
| `GZipStream` | Compresses file bytes |
| `MemoryStream` | Holds compressed data in memory |
| `BitConverter` | Converts int ↔ 4 bytes for size transmission |

---

## 🖱️ Client (Windows Forms App)

**UI Elements:**
| Element | Name | Purpose |
|---|---|---|
| Button | `Connect` | Connect to server |
| Button | `ChooseFile` | Open file picker dialog |
| Button | `Send` | Send file and receive compressed version |
| ListBox | `Logs` | Display all activity messages |

**Key classes used:**
| Class | Purpose |
|---|---|
| `TcpClient` | Manages TCP connection |
| `NetworkStream` | Sends and receives bytes |
| `OpenFileDialog` | File picker UI |
| `File.ReadAllBytes` | Reads file from disk |
| `File.WriteAllBytes` | Saves compressed file to disk |

---

## 🚀 How to Run

### 1. Run the Server
- Set `CompressionServer` as Startup Project
- Press **Run** → Console shows `Server started...`

### 2. Run the Client
- Set `CompressionClient` as Startup Project
- Press **Run** → Windows Form opens

### 3. Use the Client (in order)
```
1. Click Connect     → Logs: "Connected!"
2. Click Choose File → Pick any file from your machine
3. Click Send        → File is sent, compressed file is received and saved
```

---

## ✅ Expected Output

**Client Logs:**
```
Connected!
Selected: C:\path\to\file.txt
Sending: 5120 bytes
File sent!
Receiving compressed: 1024 bytes
Saved to: C:\path\to\file.txt.gz
```

**Server Console:**
```
Server started...
Receiving file: 5120 bytes
Compressed: 1024 bytes
Done!
```

The compressed `.gz` file is saved in the same directory as the original file.

---

## 🛠️ Technologies

- **Language:** C# / .NET
- **Networking:** `System.Net.Sockets`
- **Compression:** `System.IO.Compression.GZipStream`
- **UI:** Windows Forms

---

## 👤 Author

**Bahaa Abd El-Nasser**  
Faculty of Computers and Information  
Network Programming Course
