using TypesCommonNames;

namespace BLCommonNames
{
    public class MyHeritageHandling : IMyHeritageHandling
    {
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
                insertUpdate.Status = InsertUpdateResponse.StatusEnum.NotOk;
                return false;
            }

            if (string.IsNullOrWhiteSpace(request.Filename))
            {
                insertUpdate.Error = "Kein Dateiname übergeben";
                insertUpdate.Status = InsertUpdateResponse.StatusEnum.NotOk;
                return false;
            }

            // Johann-Horst Huber Liste der DNA Matches 8. Oktober 2019-MH-8E22A7.csv


            //if (arr.Length == 0)
            //{
            //    insertUpdate = new InsertUpdateResponse()
            //    {
            //        Error = "Falscher Dateiname: " + request.Filename,
            //        Status = InsertUpdateResponse.StatusEnum.Nook
            //    };
            //    return false;
            //}

            //kitNr = XXX
            

            insertUpdate.Status = InsertUpdateResponse.StatusEnum.Ok;

            return true;
        }

    }
}
