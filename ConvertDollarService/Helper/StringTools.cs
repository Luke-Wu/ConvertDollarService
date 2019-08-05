using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConvertDollarService
{
    public static class StringTools
    {

        /// <summary>
        /// Get left part of string
        /// </summary>
        /// <param name="source">origial string</param>
        /// <param name="length">the length of left part</param>
        /// <returns></returns>
        public static string Left(this string source, int length)
        {
            if (length >= 0 && length <= source.Length)
            {
                return source.Substring(0, length);
            }
            else
            {
                return source;
            }
        }

        /// <summary>
        /// Get right part of string
        /// </summary>
        /// <param name="source">origial string</param>
        /// <param name="length">the length of left part</param>
        /// <returns></returns>
        public static string Right(this string source, int length)
        {
            if (length >= 0 && length <= source.Length)
            {
                return source.Substring(source.Length - length, length);
            }
            else
            {
                return source;
            }
        }

   

    }
}