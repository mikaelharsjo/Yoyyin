using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;
using dotless.Core;
using dotless.Core.Input;
using dotless.Core.Loggers;
using dotless.Core.configuration;

namespace Yoyyin.Mvc.Transform
{

        public class LessTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                DotlessConfiguration config = new DotlessConfiguration();
                config.MinifyOutput = false;
                config.ImportAllFilesAsLess = true;
                config.CacheEnabled = false;
                config.LessSource = typeof(VirtualFileReader);
                #if DEBUG
                config.Logger = typeof(DiagnosticsLogger);
                #endif
                response.Content = Less.Parse(response.Content, config);
                response.ContentType = "text/css";
            }

            internal sealed class VirtualFileReader : IFileReader
            {
                public byte[] GetBinaryFileContents(string fileName)
                {
                    fileName = GetFullPath(fileName);
                    return File.ReadAllBytes(fileName);
                }

                public string GetFileContents(string fileName)
                {
                    fileName = GetFullPath(fileName);
                    return File.ReadAllText(fileName);
                }

                public bool DoesFileExist(string fileName)
                {
                    fileName = GetFullPath(fileName);
                    return File.Exists(fileName);
                }

                private static string GetFullPath(string path)
                {
                    return HostingEnvironment.MapPath("~/Content/Less/" + path);
                }
            }
        }
}