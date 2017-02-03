using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Microsoft.AspNetCore.ResponseCompression.ResponseCompressionDefaults;

namespace BeamLab.Koala.Web
{
    public static class ResponseCompressionMimeTypes
    {
        public static IEnumerable<string> Defaults
            => MimeTypes.Concat(new[]
                                {
                                    "image/svg+xml",
                                    "application/font-woff2",
                                    "image/png",
                                    "image/jpeg"
                                });
    }
}
