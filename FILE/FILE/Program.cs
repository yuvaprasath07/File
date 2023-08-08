using FILE.FIle;

namespace FILE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List_Convert_Json person = new List_Convert_Json();
            //person.getPeople();

            //Excel_Read excel = new Excel_Read();
            //excel.excelRead();

            Excel_toJson excel_convert_json =new Excel_toJson();
            excel_convert_json.ExcelConvertJson();
        }
    }
}