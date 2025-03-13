using BLCommonNames;
using DLCommonNames;
using Microsoft.Extensions.Configuration;
using TypesCommonNames;

namespace TestsCommonNames
{
    [TestClass]
    public sealed class IntegrationsTest
    {
        [TestMethod]
        public void InsertUpdateOk()
        {
            var myHeritageHandling = new MyHeritageHandling();

            var fileName = "Johann Huber Liste der DNA Matches 8. Oktober 2019-MH-8E22A7.csv";
            var path = Path.Combine("Data", fileName);
            var data = File.ReadAllBytes(path);

            var request = new InsertUpdateRequest()
            {
                Data = data,
                Filename = fileName
            };
            var response = myHeritageHandling.InsertUpdate(request);
        }


        [TestMethod]
        public void InstanceMiscData()
        {
            string kitNr = "MH-K733W2";
            int companyId = 1;
            int kitTypeId = 1;

            bool miscdata = MiscData.IsKitNrAllowed(kitNr, companyId, kitTypeId);

            Assert.IsTrue(miscdata);
        }
    }
}
