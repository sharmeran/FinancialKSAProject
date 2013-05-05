using Excel;
using FSP.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Domain.Domains.Financial
{
    public class MainFinancialDomain
    {
        public Dictionary<string, decimal> ProcessingData(string fileName, ActionState actionState)
        {
            
            Dictionary<string, decimal> dataBank = new Dictionary<string, decimal>();
            try
            {
                FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                //TextWriter txt = new StreamWriter("c:\\text.txt");
                string[] fileNameSplit = fileName.Split('.');
                IExcelDataReader excelReader = null;
                if (fileNameSplit[1] == "xls")
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (fileNameSplit[1] == "xlsx")
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else
                {
                    actionState.SetFail(Common.Enums.ActionStatusEnum.Exception, "يجب اختيار ملفات اكسل فقط");
                }

                if (actionState.Result == null)
                {
                    DataSet result = excelReader.AsDataSet();
                    int count = 0;
                    for (int i = 14; i < result.Tables[0].Rows.Count; i++)
                    {
                        if (result.Tables[0].Rows[i].ItemArray[1].ToString().Trim() != string.Empty && (result.Tables[0].Rows[i].ItemArray[3].ToString().Trim() != string.Empty && result.Tables[0].Rows[i].ItemArray[3].ToString().Trim() != "-"))
                        {
                            string key = result.Tables[0].Rows[i].ItemArray[1].ToString();
                            key = key.Replace('-', ' ').Trim();
                            key = key.Replace('+', ' ').Trim();

                            if (dataBank.ContainsKey(key) == false)
                            {
                                decimal value = 0;
                                bool resultValue = false;
                                resultValue = decimal.TryParse((result.Tables[0].Rows[i].ItemArray[3]).ToString().Trim(), out value);
                                if (resultValue == true)
                                    dataBank.Add(key, value);
                            }
                            else
                            {
                                decimal value = 0;
                                bool resultValue = false;
                                resultValue = decimal.TryParse((result.Tables[0].Rows[i].ItemArray[3]).ToString().Trim(), out value);
                                if (resultValue == true)
                                    dataBank.Add(key + count, value);
                                count++;

                            }
                        }
                    }
                    actionState.SetSuccess();
                }
                
            }
            catch (Exception ex)
            {
                actionState.SetFail(Common.Enums.ActionStatusEnum.Exception, ex.Message);
            }
            //txt.Close();
            return dataBank;
        }


        public decimal GetValue(Dictionary<string, decimal> dataBank, string key)
        {
            if(dataBank.ContainsKey(key))
                return dataBank[key];
            else return 0;
        }
    }
}
