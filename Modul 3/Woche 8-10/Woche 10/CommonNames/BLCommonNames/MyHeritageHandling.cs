using ConfigCommonNames;
using System.Text.RegularExpressions;
using TypesCommonNames;
using static TypesCommonNames.Enums;

namespace BLCommonNames
{
    public class MyHeritageHandling : IMyHeritageHandling
    {

        static MyHeritageHandling()
        {
            KitNrPattern = ClassBase.Config["KitNrPattern:MyHeritage"];
        }

        private static string KitNrPattern;

        public InsertUpdateResponse InsertUpdate(InsertUpdateRequest request)
        {
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            if (!RequestIsValid(request, out InsertUpdateResponse insertUpdateResponse, out string kitNr))
                return insertUpdateResponse;



            return new InsertUpdateResponse();
        }


        private static bool RequestIsValid(InsertUpdateRequest request, out InsertUpdateResponse insertUpdate, out string kitNr)
        {
            kitNr = string.Empty;
            insertUpdate = new InsertUpdateResponse();

            if (request.Data == null || request.Data.Length == 0)
            {
                insertUpdate.Error = "Die Datei ist leer bzw. nicht übergeben";
                insertUpdate.Status = StatusEnum.NotOk;
                return false;
            }

            if (string.IsNullOrWhiteSpace(request.Filename))
            {
                insertUpdate.Error = "Kein Dateiname übergeben";
                insertUpdate.Status = StatusEnum.NotOk;
                return false;
            }

            //char hyphen = '-';
            //string[] arr = request.Filename.Split(hyphen);
            //if (arr.Length == 0)
            //{
            //    insertUpdate.Error = "Falscher Dateiname: " + request.Filename;
            //    insertUpdate.Status = StatusEnum.NotOk;
            //    return false;
            //}

            //kitNr = arr[arr.Length - 2] + hyphen + arr[arr.Length - 1].ToUpper().Replace(".CSV","");


            var match = Regex.Match(request.Filename, KitNrPattern);

            if (!match.Success)
            {
                insertUpdate.Error = "Falscher Dateiname: " + request.Filename;
                insertUpdate.Status = StatusEnum.NotOk;
                return false;
            }

            kitNr = match.Value;

            // 



            insertUpdate.Status = StatusEnum.Ok;

            return true;
        }

    }
}
