using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DiscordLeech
{
    internal static class Leech
    {
        /*
         * https://github.com/SamuelTulach/DiscordLeech
         */

        public struct UserData
        {
            public string Id;
            public string Username;
            public string Discriminator;
            public string Avatar;
        }

        private enum AllocationProtect : uint
        {
            PAGE_EXECUTE = 0x00000010,
            PAGE_EXECUTE_READ = 0x00000020,
            PAGE_EXECUTE_READWRITE = 0x00000040,
            PAGE_EXECUTE_WRITECOPY = 0x00000080,
            PAGE_NOACCESS = 0x00000001,
            PAGE_READONLY = 0x00000002,
            PAGE_READWRITE = 0x00000004,
            PAGE_WRITECOPY = 0x00000008,
            PAGE_GUARD = 0x00000100,
            PAGE_NOCACHE = 0x00000200,
            PAGE_WRITECOMBINE = 0x00000400
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MEMORY_BASIC_INFORMATION
        {
            public ulong BaseAddress;
            public ulong AllocationBase;
            public int AllocationProtect;
            public int __alignment1;
            public ulong RegionSize;
            public int State;
            public AllocationProtect Protect;
            public int Type;
            public int __alignment2;
        }

        [DllImport("kernel32.dll")]
        private static extern int VirtualQueryEx(IntPtr hProcess, ulong lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);

        [Flags]
        private enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, ulong lpBaseAddress, [Out] byte[] lpBuffer, ulong dwSize, out IntPtr lpNumberOfBytesRead);

        private static int FindPattern(byte[] src, byte[] pattern)
        {
            var maxFirstCharSlot = src.Length - pattern.Length + 1;
            for (var i = 0; i < maxFirstCharSlot; i++)
            {
                if (src[i] != pattern[0])
                    continue;

                for (var j = pattern.Length - 1; j >= 1; j--)
                {
                    if (src[i + j] != pattern[j])
                        break;
                    if (j == 1)
                        return i;
                }
            }

            return -1;
        }

        private static string GetBetween(string input, string first, string second)
        {
            if (!input.Contains(first) || !input.Contains(second))
                throw new Exception("Text does not contain our data");

            var startPosition = input.IndexOf(first) + first.Length;
            var after = input.Substring(startPosition, input.Length - startPosition);
            var endPosition = after.IndexOf(second) + startPosition;
            return input.Substring(startPosition, endPosition - startPosition);
        }

        private static bool CheckRegion(IntPtr processHandle, ulong regionStart, ulong regionSize, out UserData data)
        {
            data = new UserData();
            var readBytes = new byte[regionSize];
            IntPtr bytesRead;
            var status = ReadProcessMemory(processHandle, regionStart, readBytes, regionSize, out bytesRead);
            if (!status)
                return false;

            var textBytes = Encoding.UTF8.GetBytes("users\":[{\"id\":\"");
            var output = FindPattern(readBytes, textBytes);
            if (output == -1)
                return false;

            var maxLength = readBytes.Length - output;
            var text = Encoding.UTF8.GetString(readBytes, output, maxLength);

            var userId = GetBetween(text, "\"id\":\"", "\"");
            var avatar = GetBetween(text, "\"avatar\":\"", "\"");
            var username = GetBetween(text, "\"username\":\"", "\"");
            var discriminator = GetBetween(text, "\"discriminator\":\"", "\"");

            data.Id = userId;
            data.Avatar = avatar;
            data.Username = username;
            data.Discriminator = discriminator;

            return true;
        }

        private static bool CheckProcess(IntPtr processHandle, out UserData data)
        {
            data = new UserData();
            ulong currentAddress = 0;

            while (true)
            {
                var size = VirtualQueryEx(processHandle, currentAddress, out var memoryInformation, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                if (size == 0)
                    break;

                currentAddress = memoryInformation.BaseAddress + memoryInformation.RegionSize;

                if (memoryInformation.Protect != AllocationProtect.PAGE_READWRITE)
                    continue;

                var status = CheckRegion(processHandle, memoryInformation.BaseAddress, memoryInformation.RegionSize, out data);
                if (status)
                    return true;
            }

            return false;
        }

        public static UserData ReadData()
        {
            var processList = Process.GetProcessesByName("Discord");
            if (processList.Length == 0)
                throw new Exception("Discord process not found");

            UserData data;
            foreach (var process in processList)
            {
                var handle = OpenProcess(ProcessAccessFlags.All, false, process.Id);
                if (handle == INVALID_HANDLE_VALUE)
                    throw new Exception("Failed to open process");

                var status = CheckProcess(handle, out data);
                if (status)
                    return data;
            }

            throw new Exception("Could not find data in process");
        }
    }
}