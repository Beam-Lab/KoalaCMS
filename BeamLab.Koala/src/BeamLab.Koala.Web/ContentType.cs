using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web
{
    //
    // Summary:
    //     A list of internet media types, which are a standard identifier used on the Internet
    //     to indicate the type of data that a file contains. Web browsers use them to determine
    //     how to display, output or handle files and search engines use them to classify
    //     data files on the web.
    public static class ContentType
    {
        //
        // Summary:
        //     Atom feeds.
        public const string Atom = "application/atom+xml";
        //
        // Summary:
        //     Binary JavaScript Object Notation BSON.
        public const string Bson = "application/bson";
        //
        // Summary:
        //     Form URL Encoded.
        public const string FormUrlEncoded = "application/x-www-form-urlencoded";
        //
        // Summary:
        //     GIF image; Defined in RFC 2045 and RFC 2046.
        public const string Gif = "image/gif";
        //
        // Summary:
        //     HTML; Defined in RFC 2854.
        public const string Html = "text/html";
        //
        // Summary:
        //     JPEG JFIF image; Defined in RFC 2045 and RFC 2046.
        public const string Jpg = "image/jpeg";
        //
        // Summary:
        //     JavaScript Object Notation JSON; Defined in RFC 4627.
        public const string Json = "application/json";
        //
        // Summary:
        //     Multi-part form daata; Defined in RFC 2388.
        public const string MultipartFormData = "multipart/form-data";
        //
        // Summary:
        //     Portable Network Graphics; Registered,[8] Defined in RFC 2083.
        public const string Png = "image/png";
        //
        // Summary:
        //     Textual data; Defined in RFC 2046 and RFC 3676.
        public const string Text = "text/plain";
        //
        // Summary:
        //     Extensible Markup Language; Defined in RFC 3023
        public const string Xml = "application/xml";
        //
        // Summary:
        //     Compressed ZIP.
        public const string Zip = "application/zip";
    }
}
