using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FSP.Windows.CommonView
{
   public static class Helper
    {
       public static string ConvertDateCalendar(DateTime DateConv, CalendarEnum Calendar)
       {
           DateTimeFormatInfo DTFormat;
           string date;
           if (Calendar == CalendarEnum.Hijri)
           {
               DTFormat = new System.Globalization.CultureInfo("ar-sa", false).DateTimeFormat;
           }
           else
           {
               DTFormat = new System.Globalization.CultureInfo("en-us", false).DateTimeFormat;
           }
           switch (Calendar)
           {
               case CalendarEnum.Hijri:
                   DTFormat.Calendar = new System.Globalization.UmAlQuraCalendar();
                    DTFormat.ShortDatePattern = "dd/MM/yyyy";
           date= DateConv.Date.ToString("dd/MM/yyyy", DTFormat);
                   break;

               case CalendarEnum.Gregorian:
                   DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                   
                   CultureInfo arCul = new CultureInfo("ar-SA");
                   CultureInfo enCul = new CultureInfo("en-US");

                   DateConv=DateTime.ParseExact(DateConv.Date.ToString("dd/MM/yyyy"),"dd/MM/yyyy",arCul.DateTimeFormat,DateTimeStyles.AllowWhiteSpaces);
                   date = DateConv.ToString("dd/MM/yyyy", enCul.DateTimeFormat);
                   break;

               default:
                   return "";
           }
           return date;
          
       }

      public static bool CheckDateHijri(string date)
       {

           string pattern = @"^([1-9]|(0|1|2)[0-9]|30)(/|-)([1-9]|1[0-2]|0[1-9])(/|-)(14[0-9]{2})$";
           bool result = false;
           result=Regex.IsMatch(date, pattern);
           return result;
       }

      public static bool CheckDateGer(string date)
       {
           string pattern = @"(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)";
           bool result = false;
           result = Regex.IsMatch(date, pattern);
           return result;
       }
    }
}
