using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MokebMangerDesktopApp
{
    internal class DashboardPanel
    {

        const string ENVIRONMENT_PATH = @".\release_v1\angularapp\src\environments\environment.ts";


        private Process _process = null;


        public bool IsProcessNull()
        {
            return (_process == null) ? true : false;
        }

        public async void KillProcess()
        {
            try
            {
                if (_process != null && !_process.HasExited)
                {
                    _process.Kill();
                    await _process.WaitForExitAsync();
                    _process.Dispose();
                    _process = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while killing the process: {ex.Message}");
            }
        }

        public async Task<bool> RunCmdFile(string command, string completedProcess)
        {
            string cmdFilePath = command;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/c \"{cmdFilePath}\"";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            _process = new Process();
            _process.StartInfo = startInfo;

            try
            {
                _process.Start();

                // Read the standard output line by line
                using (StreamReader reader = _process.StandardOutput)
                {
                    string line;
                    while (true)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            if (line.Contains(completedProcess))
                            {

                                return true;
                            }
                        }
                    }
                }

                // Read the error output line by line
                using (StreamReader reader = _process.StandardError)
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        MessageBox.Show("Error: " + line);
                    }
                }

                _process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return false;
        }




        /// <summary>
        /// Updates the IP address in the environment file.
        /// </summary>
        public string SetLocalIp()
        {
            try
            {
                string fileContent = File.ReadAllText(ENVIRONMENT_PATH);
                string localIp = GetLocalIPAddress();

                fileContent = UpdateIssuerUrl(fileContent, localIp);
                fileContent = UpdateOtherUrl(fileContent, localIp);

                File.WriteAllText(ENVIRONMENT_PATH, fileContent);

                Console.WriteLine("Local IP has been set successfully.");

                return localIp;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while setting the local IP: {e.Message}");

                return null;
            }
        }

        /// <summary>
        /// Retrieves the local IP address of the machine.
        /// </summary>
        /// <returns>The local IPv4 address.</returns>
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Updates the issuer URL in the file content with the local IP address.
        /// </summary>
        /// <param name="fileContent">The content of the environment file.</param>
        /// <param name="localIp">The local IP address to use.</param>
        /// <returns>The updated file content.</returns>
        private static string UpdateIssuerUrl(string fileContent, string localIp)
        {
            string pattern = @"issuer:\s*""https?://[^""]*""";
            string replacement = $"issuer: 'https://{localIp}:44355/'";
            return Regex.Replace(fileContent, pattern, replacement);
        }

        /// <summary>
        /// Updates other URLs in the file content with the local IP address.
        /// </summary>
        /// <param name="fileContent">The content of the environment file.</param>
        /// <param name="localIp">The local IP address to use.</param>
        /// <returns>The updated file content.</returns>
        private static string UpdateOtherUrl(string fileContent, string localIp)
        {
            string pattern = @"url:\s*""https?://[^""]*""";
            string replacement = $"url: 'https://{localIp}:44355'";
            return Regex.Replace(fileContent, pattern, replacement);
        }
    }
}
