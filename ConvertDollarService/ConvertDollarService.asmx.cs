using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ConvertDollarService
{
    /// <summary>
    /// Summary description for ConvertDollarService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ConvertDollarService : System.Web.Services.WebService
    {

        /// <summary>
        /// Web method to get words of dollars
        /// </summary>
        /// <param name="strDollars">The origin text includes name and dollars</param>
        /// <returns></returns>
        [WebMethod]
        public string TranslateDollars(string strDollars)
        {
            var rtrStr = string.Empty;
            var numericHandler = new NumericHandler();

            string[] strArray = strDollars.Split(new char[] { ' ','\n' });
            if (strArray.Length > 0)
            {
                var lastStr = strArray[strArray.Length - 1];
                var numericStr = strArray[strArray.Length - 1].TrimStart(new char[] { '"' }).TrimEnd(new char[] { '"' });

                if (Double.TryParse(numericStr, out double dollars))
                {
                    var dollarText = numericHandler.GetDollarsText(dollars);

                    rtrStr = strDollars.Substring(0, (strDollars.Length - lastStr.Length - 1)) + " \"" + dollarText + "\"";
                }
                else
                {
                    rtrStr = strDollars;
                }
            }
            return rtrStr;
        }
    }
}
