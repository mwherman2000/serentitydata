using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace X509CertificateLedgerEntry
{
    class Program
    {
        static void Main(string[] args)
        {
            // The path to the certificate.
            string[] filenames = { "..\\..\\..\\Certificates\\TUBITAK Kamu SM SSL Kok Sertifikasi - Suram 1.cer",
                                   "..\\..\\..\\Certificates\\IISExpressExport.pfx",
                                   "..\\..\\..\\Certificates\\EntrustRootCertificationAuthority.cer",
                                   "..\\..\\..\\Certificates\\VeriSign Universal Root Certification Authority.cer"};

            foreach (string filename in filenames)
            {
                Console.WriteLine();
                Console.WriteLine($"filename:\t`{filename}`");
                X509Certificate cert = new X509Certificate(filename, "evlewt12");

                string resultsTrue = cert.ToString(true);
                Console.WriteLine($"resultsTrue:\t`{resultsTrue}`");

                string resultsFalse = cert.ToString(false);
                Console.WriteLine($"resultsFalse:\t`{resultsFalse}`");

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(cert);
                Console.WriteLine($"json:\t`{json}`");
            }

            string[] filenames2 = Directory.GetFiles("..\\..\\..\\VMCA");
            foreach (string filename in filenames2)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine($"filename:\t`{filename}`");
                    X509Certificate cert = new X509Certificate(filename, "P@ssword1");

                    string resultsTrue = cert.ToString(true);
                    Console.WriteLine($"resultsTrue:\t`{resultsTrue}`");

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(cert);
                    Console.WriteLine($"json:\t`{json}`");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"filename {filename}: {ex.ToString()}");
                }
            }

            Console.WriteLine("==================================================");
            string filename10 = "..\\..\\..\\VMCA\\WebServerCert2.cer"; // UserCert10.pfx";
            Console.WriteLine($"filename10:\t`{filename10}`");

            //X509Certificate cert10 = new X509Certificate(filename10, "P@ssword1");
            //X509Certificate2 cert10x = (X509Certificate2)cert10;

            //X509Certificate2 x509 = new X509Certificate2();
            ////Create X509Certificate2 object from .cer file.
            //byte[] rawData = File.ReadAllBytes(filename10);
            //x509.Import(rawData);

            X509Certificate2 x509 = new X509Certificate2(filename10, "P@ssword1");

            //Print to console information contained in the certificate.
            Console.WriteLine("{0}Subject: {1}{0}", Environment.NewLine, x509.Subject);
            Console.WriteLine("{0}Issuer: {1}{0}", Environment.NewLine, x509.Issuer);
            Console.WriteLine("{0}Version: {1}{0}", Environment.NewLine, x509.Version);
            Console.WriteLine("{0}Valid Date: {1}{0}", Environment.NewLine, x509.NotBefore);
            Console.WriteLine("{0}Expiry Date: {1}{0}", Environment.NewLine, x509.NotAfter);
            Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, x509.Thumbprint);
            Console.WriteLine("{0}Serial Number: {1}{0}", Environment.NewLine, x509.SerialNumber);
            Console.WriteLine("{0}Friendly Name: {1}{0}", Environment.NewLine, x509.PublicKey.Oid.FriendlyName);
            Console.WriteLine("{0}Public Key Format: {1}{0}", Environment.NewLine, x509.PublicKey.EncodedKeyValue.Format(true));
            Console.WriteLine("{0}Raw Data Length: {1}{0}", Environment.NewLine, x509.RawData.Length);
            Console.WriteLine("{0}Certificate to string: {1}{0}", Environment.NewLine, x509.ToString(true));

            Console.WriteLine("{0}Certificate to XML String: {1}{0}", Environment.NewLine, x509.PublicKey.Key.ToXmlString(false));



            Console.ReadKey();
        }
    }
}
